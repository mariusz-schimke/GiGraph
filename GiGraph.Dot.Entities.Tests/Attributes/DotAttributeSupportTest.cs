using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Entities.Types.Attributes;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class DotAttributeSupportTest
    {
        [Fact]
        public void graph_supports_correct_attribute_keys()
        {
            var keys = GetSupportedKeysFor(DotEntityTypes.Graph);

            var graph = new DotGraph();
            var graphKeyMapping = graph.Attributes.GetKeyMapping();
            var graphClusterKeyMapping = graph.Clusters.Attributes.GetKeyMapping();

            AssertSupportsValidAttributes(graphKeyMapping, keys);
            AssertSupportsValidAttributes(graphClusterKeyMapping, keys);
        }

        [Fact]
        public void cluster_supports_correct_attribute_keys()
        {
            var keys = GetSupportedKeysFor(DotEntityTypes.Cluster);
            var mapping = new DotCluster("").Attributes.GetKeyMapping();

            AssertSupportsValidAttributes(mapping, keys);
        }

        [Fact]
        public void subgraph_supports_correct_attribute_keys()
        {
            var keys = GetSupportedKeysFor(DotEntityTypes.Subgraph);
            var mapping = new DotSubgraph().Attributes.GetKeyMapping();

            AssertSupportsValidAttributes(mapping, keys);
        }
        
        [Fact]
        public void node_supports_correct_attribute_keys()
        {
            var keys = GetSupportedKeysFor(DotEntityTypes.Node);
            var mapping = new DotNode("").Attributes.GetKeyMapping();

            AssertSupportsValidAttributes(mapping, keys);
        }
        
        [Fact]
        public void edge_supports_correct_attribute_keys()
        {
            var keys = GetSupportedKeysFor(DotEntityTypes.Edge);
            var mapping = new DotEdge("").Attributes.GetKeyMapping();

            AssertSupportsValidAttributes(mapping, keys);
        }

        private void AssertSupportsValidAttributes(Dictionary<string, string> entityKeyMapping, string[] validKeys)
        {
            var result = entityKeyMapping.Keys
               .Except(validKeys.Intersect(entityKeyMapping.Keys))
               .ToArray();

            if (result.Any())
            {
                throw new Exception($"Incorrect attributes for entity: {string.Join(", ", result)}");
            }
        }

        private static string[] GetSupportedKeysFor(DotEntityTypes entityType)
        {
            return DotAttributeKeys.GetSupportMapping()
               .Where(item => item.Value.HasFlag(entityType))
               .Select(item => item.Key)
               .ToArray();
        }
    }
}