using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Nodes;
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

        graph.Nodes.Add("node", c =>
                c.Style.Set(DotNodeFillStyle.None, DotBorderStyle.Solid, DotBorderWeight.Bold, DotCornerStyle.Rounded, true, true)
            )
           .SetPlainColorFill(Color.Red);

        graph.Nodes.Style.Set(DotNodeFillStyle.None, DotBorderStyle.Solid, DotBorderWeight.Bold, DotCornerStyle.Rounded, true, true);
        graph.Nodes.SetPlainColorFill(Color.Red);

        Snapshot.Match(graph.Build(), "gradient_fill_on_nodes_with_other_styles_set");
    }

    [Fact]
    public void sets_plain_color_fill_on_node()
    {
        var graph = new DotGraph();
        graph.Nodes.Add("node").SetPlainColorFill(Color.Red);
        Snapshot.Match(graph.Build(), "plain_color_fill_on_node");
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