using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Entities.Tests.Attributes.Helpers;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Metadata;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes;

public class DotAttributePropertiesTest
{
    [Fact]
    public void all_entity_attributes_class_descendants_implement_the_interface_passed_to_them_as_the_generic_argument()
    {
        var types = Assembly.GetAssembly(typeof(DotEntityAttributes<,>))!.GetTypes()
            .Where(t => !t.IsAbstract)
            .Where(t => t.IsAssignableTo(typeof(DotEntityAttributes)))
            .ToArray();

        Assert.NotEmpty(types);

        foreach (var sourceType in types)
        {
            var type = sourceType;

            do
            {
                // this ensures that we get to DotEntityAttributes<,>, which is the direct descendant of DotEntityAttributes
                if (type.BaseType != typeof(DotEntityAttributes))
                {
                    type = type.BaseType;
                    continue;
                }

                var genericArguments = type.GetGenericArguments();
                var entityAttributeInterfaceType = genericArguments[0];
                var entityAttributeImplementationType = genericArguments[1];

                Assert.True(entityAttributeInterfaceType.IsInterface);
                Assert.False(entityAttributeImplementationType.IsInterface);

                var entityAttributesImplementationType = typeof(DotEntityAttributes<,>).MakeGenericType(entityAttributeInterfaceType, entityAttributeImplementationType);

                // ensure that the type is assignable to DotEntityAttributes<,> to make sure no type inherits directly
                // from the non-generic DotEntityAttributes base type
                Assert.True(sourceType.IsAssignableTo(entityAttributesImplementationType));

                // Ensure that the same type is also assignable to the interface used as the first generic argument.
                // The assumption is that the same class that inherits from DotEntityAttributes<IMyAttributesInterface, IMyEntity>
                // should also implement the interface IMyAttributesInterface passed as the generic argument. If another type
                // is used as the implementation parameter, it may be a mistake.
                Assert.True(sourceType.IsAssignableTo(entityAttributeInterfaceType));

                AssertNoPublicAttributePropertiesWithoutInterface(entityAttributeInterfaceType, sourceType);

                break;
            } while (type is not null);

            if (type is null)
            {
                throw new Exception($"The type {sourceType.Name} is not a descendant of {nameof(DotEntityAttributes)}");
            }
        }
    }

    /// <summary>
    ///     Makes sure there are no public properties in the source type that are not defined in the interface type, and that expose
    ///     access to Graphviz attributes.
    /// </summary>
    private static void AssertNoPublicAttributePropertiesWithoutInterface(Type entityAttributeInterfaceType, Type sourceType)
    {
        var interfaceProps = entityAttributeInterfaceType
            .GetInterfaces()
            .Concat([entityAttributeInterfaceType])
            .SelectMany(i => i.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            .Select(p => (p.Name, p.PropertyType))
            .ToHashSet();

        var classProps = sourceType
            .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
            .Where(prop => prop.GetCustomAttribute<DotAttributeKeyAttribute>() is not null)
            .Select(p => (p.Name, p.PropertyType))
            .ToList();

        var extraProps = classProps
            .Where(p => !interfaceProps.Contains(p))
            .ToList();
        Assert.True(extraProps.Count == 0, $"Type {sourceType.Name} defines extra public properties not in {entityAttributeInterfaceType.Name}: {string.Join(", ", extraProps.Select(p => p.Name))}");
    }

    [Fact]
    public void all_graph_attributes_property_accessors_have_keys_available()
    {
        var graph = new DotGraph();
        ReadAndWriteAttributeProperties(graph.Attributes, graph.Attributes.GetMetadataDictionary().Values.ToArray());
    }

    [Fact]
    public void all_cluster_attributes_property_accessors_have_keys_available()
    {
        var cluster = new DotCluster("");
        ReadAndWriteAttributeProperties(cluster.Attributes, cluster.Attributes.GetMetadataDictionary().Values.ToArray());
    }

    [Fact]
    public void all_subgraph_attributes_property_accessors_have_keys_available()
    {
        var subgraph = new DotSubgraph();
        ReadAndWriteAttributeProperties(subgraph.Attributes, subgraph.Attributes.GetMetadataDictionary().Values.ToArray());
    }

    [Fact]
    public void all_node_attributes_property_accessors_have_keys_available()
    {
        var node = new DotNode("");
        ReadAndWriteAttributeProperties(node.Attributes, node.Attributes.GetMetadataDictionary().Values.ToArray());
    }

    [Fact]
    public void all_edge_attributes_property_accessors_have_keys_available()
    {
        var edge = new DotEdge("");
        ReadAndWriteAttributeProperties(edge.Attributes, edge.Attributes.GetMetadataDictionary().Values.ToArray());
    }

    private static void ReadAndWriteAttributeProperties(IDotEntityAttributesAccessor targetRootObject, DotAttributePropertyMetadata[] attributes)
    {
        var propertyTree = DotPropertyTreeFactory.GetFlattenedPropertyTreeByMetadata(targetRootObject, attributes);

        foreach (var propertySubtree in propertyTree)
        {
            foreach (var property in propertySubtree)
            {
                InvokeGetterValid(propertySubtree.Key, property);
                InvokeSetterValid(propertySubtree.Key, property);

                EnsureInterfacePropertiesHaveAttributeKeysAssigned(propertySubtree.Key, property);
            }
        }
    }

    private static void InvokeSetterValid(object target, PropertyInfo targetProperty)
    {
        try
        {
            if (targetProperty.GetSetMethod(nonPublic: true) is not null)
            {
                targetProperty.SetValue(target, null);
            }
        }
        catch (Exception e)
        {
            throw new Exception($"Error writing property {targetProperty.Name}", e);
        }
    }

    private static void InvokeGetterValid(object target, PropertyInfo targetProperty)
    {
        try
        {
            if (targetProperty.GetGetMethod(nonPublic: true) is not null)
            {
                targetProperty.GetValue(target);
            }
        }
        catch (Exception e)
        {
            throw new Exception($"Error reading property {targetProperty.Name}", e);
        }
    }

    private static void EnsureInterfacePropertiesHaveAttributeKeysAssigned(DotEntityAttributes targetObject, PropertyInfo targetProperty)
    {
        var tested = 0;

        // it is assumed that the metadata dictionary that the target property comes from, contains interface properties
        Assert.True(targetProperty.ReflectedType!.IsInterface);

        // some interfaces extend other interfaces, but they are treated as if they were separate
        // from the implementing type perspective, so we need to get the current interface and all interfaces it extends
        var interfaces = targetProperty.ReflectedType!.GetInterfaces()
            .Append(targetProperty.ReflectedType);

        foreach (var @interface in interfaces)
        {
            foreach (var property in @interface.GetRuntimeProperties())
            {
                var accessor = ((IDotEntityAttributes) targetObject).Accessor;

                // should throw an exception if no key is available for a property
                var key = accessor.GetPropertyKey(property);
                Assert.NotEmpty(key);

                tested++;
            }
        }

        // just to be sure that the filtering conditions are formulated properly and anything is tested actually
        Assert.True(tested > 0);
    }
}