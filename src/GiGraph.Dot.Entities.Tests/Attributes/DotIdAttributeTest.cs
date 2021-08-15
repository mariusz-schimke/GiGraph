using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Identifiers;
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

            graph.Edges.AddLoop("node1").HeadAttributes.ClusterId = null;
            graph.Edges.AddLoop("node2").HeadAttributes.ClusterId = "cluster1";
            graph.Edges.AddLoop("node3").HeadAttributes.ClusterId = new DotClusterId(null);

            Snapshot.Match(graph.Build(), "cluster_id_attribute.gv");
        }

        [Fact]
        public void root_node_id_attribute_is_encoded_correctly()
        {
            var graph = new DotGraph();

            graph.Subsections.Add().RootNodeId = null;
            graph.Subsections.Add().RootNodeId = "root";
            graph.Subsections.Add().RootNodeId = new DotId(null);
            graph.Subsections.Add().RootNodeId = new DotClusterId("root");

            Snapshot.Match(graph.Build(), "root_node_id_attribute.gv");
        }
    }
}