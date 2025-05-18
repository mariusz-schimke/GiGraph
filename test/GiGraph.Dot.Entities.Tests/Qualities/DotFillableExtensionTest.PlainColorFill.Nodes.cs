using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Nodes.Style;
using GiGraph.Dot.Types.Styling;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public partial class DotFillableExtensionTest
{
    [Fact]
    public void does_not_overwrite_other_node_style_flags()
    {
        var graph = new DotGraph();

        graph.Nodes
            .Add("node", n => SetAllStyleOptions(n.Style))
            .Style
            .SetPlainFill(Color.Red);

        SetAllStyleOptions(graph.Nodes.Style);
        graph.Nodes.Style.SetPlainFill(Color.Red);

        Snapshot.Match(graph.ToDot(), "gradient_fill_on_nodes_with_other_styles_set");
    }

    [Fact]
    public void sets_plain_color_fill_on_node()
    {
        var graph = new DotGraph();
        graph.Nodes.Add("node").Style.SetPlainFill(Color.Red);
        Snapshot.Match(graph.ToDot(), "plain_color_fill_on_node");
    }

    [Fact]
    public void sets_plain_color_fill_on_node_group()
    {
        var graph = new DotGraph();
        graph.Nodes.AddGroup(["node1", "node2"]).Style.SetPlainFill(Color.Red);
        Snapshot.Match(graph.ToDot(), "plain_color_fill_on_node_group");
    }

    [Fact]
    public void sets_plain_color_fill_on_node_collection()
    {
        var graph = new DotGraph();
        graph.Nodes.Style.SetPlainFill(Color.Red);
        Snapshot.Match(graph.ToDot(), "plain_color_fill_on_node_collection");
    }

    private void SetAllStyleOptions(DotNodeStyleAttributes nodeStyle, DotNodeFillStyle fillStyle = DotNodeFillStyle.None)
    {
        nodeStyle.FillStyle = fillStyle;
        nodeStyle.BorderStyle = DotBorderStyle.Solid;
        nodeStyle.BorderWeight = DotBorderWeight.Bold;
        nodeStyle.CornerStyle = DotCornerStyle.Rounded;
        nodeStyle.Diagonals = true;
        nodeStyle.Invisible = true;
    }
}