using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Colors;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities
{
    public partial class DotFillableExtensionTest
    {
        [Fact]
        public void sets_radial_gradient_fill_on_node()
        {
            var graph = new DotGraph();

            graph.Nodes.Add("node1").SetRadialGradientFill(new DotGradientColor(Color.Red, Color.Brown));
            graph.Nodes.Add("node2").SetRadialGradientFill(new DotGradientColor(Color.Red, Color.Brown), 45);

            Snapshot.Match(graph.Build(), "radial_gradient_fill_on_nodes");
        }

        [Fact]
        public void sets_radial_gradient_fill_on_node_group()
        {
            var graph = new DotGraph();

            graph.Nodes.AddGroup("node1", "node2").SetRadialGradientFill(new DotGradientColor(Color.Red, Color.Brown));
            graph.Nodes.AddGroup("node3", "node4").SetRadialGradientFill(new DotGradientColor(Color.Red, Color.Brown), 45);

            Snapshot.Match(graph.Build(), "radial_gradient_fill_on_node_groups");
        }

        [Fact]
        public void sets_radial_gradient_fill_on_node_collection()
        {
            var graph = new DotGraph();
            graph.Nodes.SetRadialGradientFill(new DotGradientColor(Color.Red, Color.Brown));

            Snapshot.Match(graph.Build(), "radial_gradient_fill_on_node_collection");
        }

        [Fact]
        public void sets_radial_gradient_fill_with_angle_on_node_collection()
        {
            var graph = new DotGraph();
            graph.Nodes.SetRadialGradientFill(new DotGradientColor(Color.Red, Color.Brown), 45);

            Snapshot.Match(graph.Build(), "radial_gradient_fill_on_node_collection_with_angle");
        }
    }
}