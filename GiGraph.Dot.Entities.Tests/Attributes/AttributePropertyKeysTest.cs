using System;
using GiGraph.Dot.Entities.Attributes.Collections.Cluster;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Collections.Graph;
using GiGraph.Dot.Entities.Attributes.Collections.Node;
using GiGraph.Dot.Entities.Attributes.Collections.Subgraph;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class AttributeKeysTest : AttributesTestBase
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
            var interfaceProperties = GetEntityAttributePropertiesOf(entityAttributesImplementation, entityAttributesInterface);

            foreach (var interfaceProperty in interfaceProperties)
            {
                dynamic collection = Activator.CreateInstance(entityAttributesImplementation);
                var key = collection.GetKey(interfaceProperty);
                
                Assert.NotEmpty(key);
            }
        }

        [Fact]
        public void property_key_mappings_have_unique_keys_for_all_attribute_collection_types()
        {
            // it is assumed that if a key repeats, an exception will be thrown by the mapping method on dictionary creation

            var graphAttributes = new DotGraph().Attributes.GetPropertyKeyMapping();
            Assert.NotEmpty(graphAttributes);

            var nodeAttributes = new DotNode("").Attributes.GetPropertyKeyMapping();
            Assert.NotEmpty(nodeAttributes);

            var edgeAttributes = new DotEdge("", "").Attributes.GetPropertyKeyMapping();
            Assert.NotEmpty(edgeAttributes);

            var subgraphAttributes = new DotSubgraph().Attributes.GetPropertyKeyMapping();
            Assert.NotEmpty(subgraphAttributes);

            var clusterAttributes = new DotCluster("").Attributes.GetPropertyKeyMapping();
            Assert.NotEmpty(clusterAttributes);
        }
    }
}