using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class DotAttributePropertyKeysTest
    {
        [Fact]
        public void property_key_mappings_are_valid()
        {
            var graphAttributes = new DotGraph().Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(graphAttributes), "graph_attribute_key_map");

            var graphClustersAttributes = new DotGraph().Clusters.Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(graphClustersAttributes), "graph_clusters_attribute_key_map");

            var clusterAttributes = new DotCluster("").Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(clusterAttributes), "cluster_attribute_key_map");

            var subgraphAttributes = new DotSubgraph().Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(subgraphAttributes), "subgraph_attribute_key_map");

            var nodeAttributes = new DotNode("").Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(nodeAttributes), "node_attribute_key_map");

            var edgeAttributes = new DotEdge("", "").Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(edgeAttributes), "edge_attribute_key_map");
        }

        [Fact]
        public void property_key_mappings_are_coherent_among_all_entities()
        {
            var graphAttributes = new DotGraph().Attributes.GetKeyMapping();
            var graphClustersAttributes = new DotGraph().Clusters.Attributes.GetKeyMapping();
            var clusterAttributes = new DotCluster("").Attributes.GetKeyMapping();
            var subgraphAttributes = new DotSubgraph().Attributes.GetKeyMapping();
            var nodeAttributes = new DotNode("").Attributes.GetKeyMapping();
            var edgeAttributes = new DotEdge("", "").Attributes.GetKeyMapping();

            var keyLookup = graphAttributes
               .Concat(graphClustersAttributes)
               .Concat(clusterAttributes)
               .Concat(subgraphAttributes)
               .Concat(nodeAttributes)
               .Concat(edgeAttributes)
               .ToLookup(
                    key => key.Key,
                    value => value.Value
                )
               .ToDictionary(
                    key => key.Key,
                    values => values.ToArray()
                );

            Snapshot.Match(new SortedDictionary<string, string[]>(keyLookup), "all_attributes_key_lookup");
        }
    }
}