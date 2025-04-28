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

        // set the same another way
        node.Style.SetStyleOptions(
            DotNodeFillStyle.Radial,
            DotBorderStyle.Dashed,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true,
            true
        );

        Snapshot.Match(graph.ToDot(), snapshotName);
    }

    [Fact]
    public void nullifying_last_style_option_nullifies_style()
    {
        var graph = new DotGraph();
        var node = graph.Nodes.Add("n1");

        Assert.False(node.Style.HasStyleOptions());

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

        Assert.True(node.Style.HasStyleOptions());
        Assert.False(node.Style.HasDefaultStyleOptions());

        node.Style.FillStyle = null;
        node.Style.BorderStyle = null;
        node.Style.BorderWeight = null;
        node.Style.CornerStyle = null;
        node.Style.Invisible = null;

        Assert.True(node.Style.HasStyleOptions());
        Assert.False(node.Style.HasDefaultStyleOptions());

        node.Style.Diagonals = false;
        Assert.True(node.Style.HasDefaultStyleOptions());

        node.Style.Diagonals = null;
        Assert.False(node.Style.HasStyleOptions());
    }

    [Fact]
    public void when_style_is_default_all_options_are_default()
    {
        var graph = new DotGraph();
        var node = graph.Nodes.Add("n1");

        Assert.False(node.Style.HasStyleOptions());

        node.Style.SetDefaultStyleOptions();

        Assert.Equal(node.Style.FillStyle, DotNodeFillStyle.None);
        Assert.Equal(node.Style.BorderStyle, DotBorderStyle.Default);
        Assert.Equal(node.Style.BorderWeight, DotBorderWeight.Default);
        Assert.Equal(node.Style.CornerStyle, DotCornerStyle.Default);
        Assert.Equal(node.Style.Diagonals, false);
        Assert.Equal(node.Style.Invisible, false);

        node.Style.ClearStyleOptions();

        Assert.Null(node.Style.FillStyle);
        Assert.Null(node.Style.BorderStyle);
        Assert.Null(node.Style.BorderWeight);
        Assert.Null(node.Style.CornerStyle);
        Assert.Null(node.Style.Diagonals);
        Assert.Null(node.Style.Invisible);
    }
}