using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Nodes;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public class DotWedgeableExtensionTest
{
    [Fact]
    public void sets_wedged_fill_on_individual_nodes()
    {
        var graph = new DotGraph();

        graph.Nodes.Add("node1").SetWedgedFill(Color.Red, Color.Blue);
        graph.Nodes.Add("node2").SetWedgedFill(new DotMulticolor(Color.Red, Color.Blue));

        graph.Nodes.Add("node3").SetWedgedFill(DotNodeShape.Rect, Color.Red, Color.Blue);
        graph.Nodes.Add("node4").SetWedgedFill(DotNodeShape.Rectangle, new DotMulticolor(Color.Red, Color.Blue));

        Snapshot.Match(graph.ToDot(), "wedged_fill_on_individual_nodes");
    }

    [Fact]
    public void sets_wedged_fill_on_individual_node_groups()
    {
        var graph = new DotGraph();

        graph.Nodes.AddGroup("node1", "node2").SetWedgedFill(Color.Red, Color.Blue);
        graph.Nodes.AddGroup("node3", "node4").SetWedgedFill(new DotMulticolor(Color.Red, Color.Blue));

        graph.Nodes.AddGroup("node5", "node6").SetWedgedFill(DotNodeShape.Rect, Color.Red, Color.Blue);
        graph.Nodes.AddGroup("node7", "node8").SetWedgedFill(DotNodeShape.Rectangle, new DotMulticolor(Color.Red, Color.Blue));

        Snapshot.Match(graph.ToDot(), "wedged_fill_on_individual_node_groups");
    }

    [Fact]
    public void sets_wedged_fill_on_node_collection()
    {
        var graph = new DotGraph();
        graph.Nodes.SetWedgedFill(Color.Red, Color.Blue);
        Snapshot.Match(graph.ToDot(), "wedged_fill_on_node_collection_params");

        graph = new DotGraph();
        graph.Nodes.SetWedgedFill(new DotMulticolor(Color.Red, Color.Blue));
        Snapshot.Match(graph.ToDot(), "wedged_fill_on_node_collection_multicolor");

        graph = new DotGraph();
        graph.Nodes.SetWedgedFill(DotNodeShape.Rect, Color.Red, Color.Blue);
        Snapshot.Match(graph.ToDot(), "wedged_fill_on_node_collection_params_and_shape");

        graph = new DotGraph();
        graph.Nodes.SetWedgedFill(DotNodeShape.Rectangle, new DotMulticolor(Color.Red, Color.Blue));
        Snapshot.Match(graph.ToDot(), "wedged_fill_on_node_collection_multicolor_and_shape");
    }
}