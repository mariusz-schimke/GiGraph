using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Colors;
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

        // set by class
        node.Style.SetStyleOptions(
            new DotNodeStyleOptions(
                DotNodeFillStyle.Radial,
                DotBorderStyle.Dashed,
                DotBorderWeight.Bold,
                DotCornerStyle.Rounded,
                true,
                true
            )
        );

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

        node.Style.Diagonals = false;
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
        Assert.Equal(DotBorderWeight.Default, node.Style.BorderWeight);
        Assert.Equal(DotCornerStyle.Default, node.Style.CornerStyle);
        Assert.False(node.Style.Diagonals);
        Assert.False(node.Style.Invisible);

        node.Style.RemoveStyleOptions();

        Assert.Equal(default(DotNodeFillStyle), node.Style.FillStyle);
        Assert.Equal(default(DotBorderStyle), node.Style.BorderStyle);
        Assert.Equal(default(DotBorderWeight), node.Style.BorderWeight);
        Assert.Equal(default(DotCornerStyle), node.Style.CornerStyle);
        Assert.False(node.Style.Diagonals);
        Assert.False(node.Style.Invisible);
    }

    [Fact]
    public void border_setter_sets_all_attributes_except_nullified()
    {
        var graph = new DotGraph();
        var node = graph.Nodes.Add("n1");

        node.Style.BorderStyle = DotBorderStyle.Solid;
        node.Style.BorderWeight = DotBorderWeight.Default;
        node.Style.BorderWidth = 1;
        node.Style.Color = Color.Red;
        node.Style.Peripheries = 1;

        // Test style
        node.Style.SetBorder(DotBorderStyle.Dashed);
        AssertBorderState(node.Style, new BorderState(DotBorderStyle.Dashed, DotBorderWeight.Default, 1, Color.Red, 1));

        // Test weight
        node.Style.SetBorder(null, DotBorderWeight.Bold);
        AssertBorderState(node.Style, new BorderState(DotBorderStyle.Dashed, DotBorderWeight.Bold, 1, Color.Red, 1));

        // Test width
        node.Style.SetBorder(null, null, 2);
        AssertBorderState(node.Style, new BorderState(DotBorderStyle.Dashed, DotBorderWeight.Bold, 2, Color.Red, 1));

        // Test color
        node.Style.SetBorder(null, null, null, Color.Blue);
        AssertBorderState(node.Style, new BorderState(DotBorderStyle.Dashed, DotBorderWeight.Bold, 2, Color.Blue, 1));

        // Test peripheries
        node.Style.SetBorder(null, null, null, null, 3);
        AssertBorderState(node.Style, new BorderState(DotBorderStyle.Dashed, DotBorderWeight.Bold, 2, Color.Blue, 3));
    }

    private static void AssertBorderState(DotNodeStyleAttributes nodeStyle, BorderState expected)
    {
        Assert.Equal(expected.Style, nodeStyle.BorderStyle);
        Assert.Equal(expected.Weight, nodeStyle.BorderWeight);
        Assert.Equal(expected.Width, nodeStyle.BorderWidth);
        Assert.Equal(expected.Color, ((DotColor?) nodeStyle.Color)!.Color);
        Assert.Equal(expected.Peripheries, nodeStyle.Peripheries);
    }

    private record BorderState(DotBorderStyle Style, DotBorderWeight Weight, double Width, Color Color, int Peripheries);
}