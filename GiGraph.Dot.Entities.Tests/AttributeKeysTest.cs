using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.Cluster;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Collections.Graph;
using GiGraph.Dot.Entities.Attributes.Collections.Node;
using GiGraph.Dot.Entities.Attributes.Collections.Subgraph;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Entities.Tests
{
    public class AttributeKeysTest
    {
        private readonly DotGenerationOptions _generationOptions = new DotGenerationOptions();
        private readonly DotSyntaxRules _syntaxRules = new DotSyntaxRules();

        [Theory]
        [InlineData(typeof(IDotClusterAttributes), typeof(DotClusterAttributeCollection))]
        [InlineData(typeof(IDotEdgeAttributes), typeof(DotEdgeAttributeCollection))]
        [InlineData(typeof(IDotGraphAttributes), typeof(DotGraphAttributeCollection))]
        [InlineData(typeof(IDotNodeAttributes), typeof(DotNodeAttributeCollection))]
        [InlineData(typeof(IDotSubgraphAttributes), typeof(DotSubgraphAttributeCollection))]
        public void all_entity_properties_have_a_non_empty_and_unique_attribute_key_assigned(Type entityAttributesInterface, Type entityAttributesImplementation)
        {
            const bool nonPublic = true;
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            var repeatedKeys = new Dictionary<string, PropertyInfo>();

            // get all setters and getters of the interface
            var interfaceProps = entityAttributesInterface.GetProperties(flags);
            var interfacePropMethods = interfaceProps
               .ToDictionary(p => p, p => p.GetGetMethod(nonPublic))
               .Concat
                (
                    interfaceProps.ToDictionary(p => p, p => p.GetSetMethod(nonPublic))
                )
               .Where(p => p.Value is {});

            var interfaceMap = entityAttributesImplementation.GetInterfaceMap(entityAttributesInterface);

            foreach (var interfacePropMethod in interfacePropMethods)
            {
                // get an equivalent method from the implementation
                var interfaceMethodIndex = Array.FindIndex(interfaceMap.InterfaceMethods, method => method.Equals(interfacePropMethod.Value));
                var implementationMethod = interfaceMap.TargetMethods[interfaceMethodIndex];

                // find the property the implementing method is associated with
                var implementationProperty = entityAttributesImplementation
                  ?.GetProperties(flags)
                  ?.Single(propertyInfo => implementationMethod.Equals(propertyInfo.GetGetMethod(nonPublic)) ||
                                           implementationMethod.Equals(propertyInfo.GetSetMethod(nonPublic)));

                // get the attribute key attribute
                var attribute = implementationProperty.GetCustomAttribute<DotAttributeKeyAttribute>();

                Assert.NotNull(attribute);
                Assert.NotEmpty(attribute.Key);

                if (repeatedKeys.TryGetValue(attribute.Key, out var prop))
                {
                    // if already added, assert it is the same property
                    Assert.Equal(interfacePropMethod.Key, prop);
                }
                else
                {
                    repeatedKeys.Add(attribute.Key, interfacePropMethod.Key);
                }
            }
        }
    }
}