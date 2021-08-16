using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities
{
    public partial class DotFillableExtensionTest
    {
        [Fact]
        public void sets_plain_color_fill_on_node()
        {
            var graph = new DotGraph();

            graph.Nodes.Add("node").SetPlainColorFill(Color.Red);
            graph.Clusters.Add().SetPlainColorFill(Color.Red);

            Snapshot.Match(graph.Build(), "plain_color_fill_on_node_and_cluster");
        }

        [Fact]
        public void sets_plain_color_fill_on_node_group()
        {
            var graph = new DotGraph();
            graph.Nodes.AddGroup("node1", "node2").SetPlainColorFill(Color.Red);

            Snapshot.Match(graph.Build(), "plain_color_fill_on_node_group");
        }

        [Fact]
        public void sets_plain_color_fill_on_node_collection()
        {
            var graph = new DotGraph();
            graph.Nodes.SetPlainColorFill(Color.Red);
            Snapshot.Match(graph.Build(), "plain_color_fill_on_node_collection");
        }
    }
}