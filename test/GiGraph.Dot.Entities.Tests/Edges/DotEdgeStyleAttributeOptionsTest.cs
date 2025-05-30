using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Styling;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Edges;

public class DotEdgeStyleAttributeOptionsTest
{
    [Fact]
    public void all_style_properties_are_specified()
    {
        const string snapshotName = "styled_edge";
        var graph = new DotGraph();
        var edge = graph.Edges.Add("n1", "n2");

        edge.Style.LineStyle = DotLineStyle.Dashed;
        edge.Style.LineWeight = DotLineWeight.Bold;
        edge.Style.Invisible = true;

        Snapshot.Match(graph.ToDot(), snapshotName);

        Assert.False(edge.Style.HasDefaultStyleOptions());
        edge.Style.SetDefaultStyleOptions();
        Assert.True(edge.Style.HasDefaultStyleOptions());
    }

    [Fact]
    public void setting_any_single_option_default_sets_default_style()
    {
        var graph = new DotGraph();
        var edge = graph.Edges.Add("n1", "n2");

        Assert.False(edge.Style.HasStyleOptions());

        edge.Style.LineStyle = DotLineStyle.Default;

        Assert.True(edge.Style.HasStyleOptions());
        Assert.True(edge.Style.HasDefaultStyleOptions());

        edge.Style.Invisible = false;
        Assert.True(edge.Style.HasDefaultStyleOptions());
    }

    [Fact]
    public void when_style_is_default_all_options_are_default()
    {
        var graph = new DotGraph();
        var edge = graph.Edges.Add("n1", "n2");

        Assert.False(edge.Style.HasStyleOptions());

        edge.Style.SetDefaultStyleOptions();

        Assert.Equal(DotLineStyle.Default, edge.Style.LineStyle);
        Assert.Equal(DotLineWeight.Normal, edge.Style.LineWeight);
        Assert.False(edge.Style.Invisible);

        edge.Style.RemoveStyleOptions();

        Assert.Equal(DotLineStyle.Default, edge.Style.LineStyle);
        Assert.Equal(DotLineWeight.Normal, edge.Style.LineWeight);
        Assert.False(edge.Style.Invisible);
    }
}