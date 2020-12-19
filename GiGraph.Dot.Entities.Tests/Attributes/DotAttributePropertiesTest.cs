using System;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class DotAttributePropertiesTest
    {
        [Fact]
        public void all_property_accessors_have_keys_available()
        {
            // it is assumed that only implemented interface properties exist in attribute key lookups,
            // so if a property is not exposed through interface, it should throw an exception on accessing
            var elementsMetadata = DotElementAttributesMetadataFactory.Create(true);

            foreach (var elementMetadata in elementsMetadata)
            {
                object result = elementMetadata.Element switch
                {
                    DotCompatibleElements.Graph => new DotGraph().Attributes,
                    DotCompatibleElements.Graph | DotCompatibleElements.Cluster => new DotGraph().Clusters.Attributes,
                    DotCompatibleElements.Subgraph => new DotSubgraph().Attributes,
                    DotCompatibleElements.Cluster => new DotCluster("").Attributes,
                    DotCompatibleElements.Node => new DotNode("").Attributes,
                    DotCompatibleElements.Edge => new DotEdge("").Attributes,
                    _ => throw new NotSupportedException($"Unsupported element type '{elementMetadata.Element}'")
                };

                ReadAndWriteAttributeProperties(result, elementMetadata.Attributes.Values.ToArray());
            }
        }

        private static void ReadAndWriteAttributeProperties(object targetRoot, DotAttributePropertyMetadata[] attributes)
        {
            foreach (var attribute in attributes)
            {
                var target = targetRoot;
                var targetPropertyPath = attribute.GetPropertyInfoPath();
                var targetProperty = targetPropertyPath.Last();

                // get the target object by path
                foreach (var property in targetPropertyPath.Take(targetPropertyPath.Length - 1))
                {
                    target = property.GetValue(target);
                }

                InvokeGetterValid(target, targetProperty);
                InvokeSetterValid(target, targetProperty);

                EnsureInterfacePropertiesHaveAttributeKeysAssigned(target, targetProperty);
            }
        }

        private static void InvokeSetterValid(object target, PropertyInfo targetProperty)
        {
            try
            {
                if (targetProperty.GetSetMethod(nonPublic: true) is { })
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
                if (targetProperty.GetGetMethod(nonPublic: true) is { })
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
            var ignore = new[] { typeof(IDotAnnotatable) };

            foreach (var @interface in targetProperty.ReflectedType.GetInterfaces().Where(i => !ignore.Contains(i)))
            {
                foreach (var property in @interface.GetProperties(DotEntityAttributes.AttributeKeyPropertyBindingFlags))
                {
                    var getKey = (Func<PropertyInfo, string>) Delegate.CreateDelegate(typeof(Func<PropertyInfo, string>), target, "GetKey");

                    // should throw an exception if no key is available for a property
                    var key = getKey(property);
                    Assert.NotEmpty(key);
                }
            }
        }
    }
}