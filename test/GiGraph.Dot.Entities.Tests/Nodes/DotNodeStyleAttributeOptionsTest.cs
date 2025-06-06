using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Nodes.Style;
using GiGraph.Dot.Types.Styling;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Nodes;

public class DotNodeStyleAttributeOptionsTest
{
    [Fact]
    public void all_style_properties_are_specified()
    {
        const string snapshotName = "styled_node";
        var graph = new DotGraph();
        var node = graph.Nodes.Add("n1");

        node.Style.FillStyle = DotNodeFillStyle.Radial;
        node.Style.BorderStyle = DotBorderStyle.Dashed;
        node.Style.BorderWeight = DotBorderWeight.Bold;
        node.Style.CornerStyle = DotCornerStyle.Rounded;
        node.Style.DrawDiagonals = true;
        node.Style.Invisible = true;

        Snapshot.Match(graph.ToDot(), snapshotName);

        Assert.False(node.Style.HasDefaultStyleOptions());
        node.Style.SetDefaultStyleOptions();
        Assert.True(node.Style.HasDefaultStyleOptions());
    }

    [Fact]
    public void setting_any_single_option_default_sets_default_style()
    {
        var graph = new DotGraph();
        var node = graph.Nodes.Add("n1");

        Assert.False(node.Style.HasStyleOptions());

        node.Style.FillStyle = DotNodeFillStyle.None;

        Assert.True(node.Style.HasStyleOptions());
        Assert.True(node.Style.HasDefaultStyleOptions());

        node.Style.DrawDiagonals = false;
        Assert.True(node.Style.HasDefaultStyleOptions());
    }

    [Fact]
    public void when_style_is_default_all_options_are_default()
    {
        var graph = new DotGraph();
        var node = graph.Nodes.Add("n1");

        Assert.False(node.Style.HasStyleOptions());

        node.Style.SetDefaultStyleOptions();

        Assert.Equal(DotNodeFillStyle.None, node.Style.FillStyle);
        Assert.Equal(DotBorderStyle.Default, node.Style.BorderStyle);
        Assert.Equal(DotBorderWeight.Normal, node.Style.BorderWeight);
        Assert.Equal(DotCornerStyle.Sharp, node.Style.CornerStyle);
        Assert.False(node.Style.DrawDiagonals);
        Assert.False(node.Style.Invisible);

        node.Style.RemoveStyleOptions();

        Assert.Equal(default(DotNodeFillStyle), node.Style.FillStyle);
        Assert.Equal(default(DotBorderStyle), node.Style.BorderStyle);
        Assert.Equal(default(DotBorderWeight), node.Style.BorderWeight);
        Assert.Equal(default(DotCornerStyle), node.Style.CornerStyle);
        Assert.False(node.Style.DrawDiagonals);
        Assert.False(node.Style.Invisible);
    }
}