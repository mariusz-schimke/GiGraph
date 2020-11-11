using System.Collections.Generic;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class DotAttributePropertyKeysTest : DotAttributeTestBase
    {
        private readonly DotSyntaxOptions _syntaxOptions = new DotSyntaxOptions();
        private readonly DotSyntaxRules _syntaxRules = new DotSyntaxRules();

        [Fact]
        public void property_key_mappings_are_valid()
        {
            var graphAttributes = new DotGraph().Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(graphAttributes), "graph_attribute_key_map");
            
            var graphClustersAttributes = new DotGraph().Clusters.Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(graphClustersAttributes), "graph_clusters_attribute_key_map");

            var nodeAttributes = new DotNode("").Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(nodeAttributes), "node_attribute_key_map");

            var edgeAttributes = new DotEdge("", "").Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(edgeAttributes), "edge_attribute_key_map");

            var subgraphAttributes = new DotSubgraph().Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(subgraphAttributes), "subgraph_attribute_key_map");

            var clusterAttributes = new DotCluster("").Attributes.GetKeyMapping();
            Snapshot.Match(new SortedDictionary<string, string>(clusterAttributes), "cluster_attribute_key_map");
        }
    }
}