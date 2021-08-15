using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Entities.Subgraphs.Attributes;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Metadata;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class DotAttributePropertiesTest
    {
        [Fact]
        public void all_entity_attributes_generic_class_descendants_implement_the_interface_passed_to_it_as_the_generic_argument()
        {
            var types = Assembly.GetAssembly(typeof(DotEntityAttributes<>))!.GetTypes()
               .Where(t => !t.IsAbstract)
               .Where(t => t.IsAssignableTo(typeof(DotEntityAttributes)))
               .Where(t => t != typeof(DotEntityAttributes))
               .ToArray();

            Assert.NotEmpty(types);

            foreach (var sourceType in types)
            {
                var type = sourceType;

                do
                {
                    if (!type.IsGenericType)
                    {
                        type = type.BaseType;
                        continue;
                    }

                    var entityAttributeInterfaceType = type.GetGenericArguments().First();
                    Assert.True(entityAttributeInterfaceType.IsInterface);

                    var entityAttributesImplementationType = typeof(DotEntityAttributes<>).MakeGenericType(entityAttributeInterfaceType);

                    // ensure that the type is assignable to the DotEntityAttributes<> with the same generic argument
                    // (this indicates that the class of interest is a descendant of that type
                    Assert.True(sourceType.IsAssignableTo(entityAttributesImplementationType));

                    // ensure that the same type is also assignable to the interface used as a generic argument
                    // (the assumption is that the same class that inherits from DotEntityAttributes<IMyAttributesInterface>
                    // should also implement the interface IMyAttributesInterface passed as the generic argument
                    Assert.True(sourceType.IsAssignableTo(entityAttributeInterfaceType));

                    break;
                } while (type is not null);

                if (type is null)
                {
                    throw new Exception($"The type {sourceType.Name} is not a descendant of {typeof(DotEntityAttributes<>).Name}");
                }
            }
        }

        [Fact]
        public void all_property_accessors_have_keys_available()
        {
            // it is assumed that only implemented interface properties exist in attribute key lookups,
            // so if a property is not exposed through interface, it should throw an exception on accessing
            var elementsMetadata = DotElementAttributesMetadataFactory.Create(true);

            foreach (var (element, attributes) in elementsMetadata)
            {
                object result = element switch
                {
                    DotCompatibleElements.Graph => new DotGraph().Attributes,
                    DotCompatibleElements.Graph | DotCompatibleElements.Cluster => new DotGraph().Clusters.Attributes,
                    DotCompatibleElements.Subgraph => new DotSubgraph().Attributes,
                    DotCompatibleElements.Cluster => new DotCluster("").Attributes,
                    DotCompatibleElements.Node => new DotNode("").Attributes,
                    DotCompatibleElements.Edge => new DotEdge("").Attributes,
                    _ => throw new NotSupportedException($"Unsupported element type '{element}'")
                };

                ReadAndWriteAttributeProperties(result, attributes.Values.ToArray());
            }
        }

        private static void ReadAndWriteAttributeProperties(object targetRoot, IEnumerable<DotAttributePropertyMetadata> attributes)
        {
            foreach (var attribute in attributes)
            {
                var target = targetRoot;
                var targetPropertyPath = attribute.GetPropertyInfoPath();
                var targetProperty = targetPropertyPath.Last();

                // get the target object by path
                target = targetPropertyPath.Take(targetPropertyPath.Length - 1)
                   .Aggregate(target, (current, property) => property.GetValue(current));

                InvokeGetterValid(target, targetProperty);
                InvokeSetterValid(target, targetProperty);

                EnsureInterfacePropertiesHaveAttributeKeysAssigned(target, targetProperty);
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

        private static void EnsureInterfacePropertiesHaveAttributeKeysAssigned(object target, PropertyInfo targetProperty)
        {
            var ignore = new[]
            {
                typeof(IDotAnnotatable),
                typeof(IDotGraphRootAttributes),
                typeof(IDotGraphClusterRootAttributes),
                typeof(IDotClusterRootAttributes),
                typeof(IDotSubgraphRootAttributes),
                typeof(IDotNodeRootAttributes),
                typeof(IDotEdgeRootAttributes),
                typeof(IDotEdgeTailRootAttributes),
                typeof(IDotEdgeHeadRootAttributes)
            };

            var tested = 0;

            foreach (var @interface in targetProperty.ReflectedType.GetInterfaces().Where(i => !ignore.Contains(i)))
            {
                foreach (var property in @interface.GetProperties(DotEntityAttributes.AttributeKeyPropertyBindingFlags))
                {
                    var getKey = (Func<PropertyInfo, string>) Delegate.CreateDelegate(typeof(Func<PropertyInfo, string>), target, "GetKey");

                    // should throw an exception if no key is available for a property
                    var key = getKey(property);
                    Assert.NotEmpty(key);

                    tested++;
                }
            }

            // just to be sure that the filtering conditions are formulated properly and anything is tested actually
            Assert.True(tested > 0);
        }
    }
}