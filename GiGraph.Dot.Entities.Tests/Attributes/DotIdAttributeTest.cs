using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Clusters;
using GiGraph.Dot.Entities.Types.Identifiers;
using GiGraph.Dot.Extensions;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class DotIdAttributeTest
    {
        [Fact]
        public void cluster_id_attribute_is_encoded_correctly()
        {
            var graph = new DotGraph();

            graph.Edges.AddLoop("node1").Attributes.Head.ClusterId = null;
            graph.Edges.AddLoop("node2").Attributes.Head.ClusterId = "cluster1";
            graph.Edges.AddLoop("node3").Attributes.Head.ClusterId = new DotClusterId(null);

            Snapshot.Match(graph.Build(), "cluster_id_attribute.gv");
        }

        [Fact]
        public void root_node_id_attribute_is_encoded_correctly()
        {
            var graph = new DotGraph();

            graph.Subsections.Add().Attributes.RootNodeId = null;
            graph.Subsections.Add().Attributes.RootNodeId = "root";
            graph.Subsections.Add().Attributes.RootNodeId = new DotId(null);
            graph.Subsections.Add().Attributes.RootNodeId = new DotClusterId("root");

            Snapshot.Match(graph.Build(), "root_node_id_attribute.gv");
        }
    }
}