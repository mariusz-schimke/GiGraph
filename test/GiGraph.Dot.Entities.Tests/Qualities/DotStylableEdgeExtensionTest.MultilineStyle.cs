using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Colors;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public partial class DotStylableEdgeExtensionTest
{
    [Fact]
    public void throws_when_a_weighted_color_is_specified_for_multiline_style()
    {
        var graph = new DotGraph();
        var edge = graph.Edges.Add("a", "b");

        Assert.Throws<ArgumentException>(() => edge.SetMultilineStyle(4, new DotWeightedColor(Color.Red, 0.5)));

        Assert.Throws<ArgumentException>(() => edge.SetMultilineStyle(new DotWeightedColor(Color.Red, 0.5)));
        Assert.Throws<ArgumentException>(() => edge.SetMultilineStyle(new DotMulticolor(new DotWeightedColor(Color.Red, 0.5))));
    }

    [Fact]
    public void sets_multiline_style_on_edges()
    {
        var graph = new DotGraph();

        graph.Edges.Add("a", "b").SetMultilineStyle(4);
        graph.Edges.Add("c", "d").SetMultilineStyle(4, Color.Red);

        graph.Edges.Add("e", "f").SetMultilineStyle(Color.Red, Color.Black, Color.Green);
        graph.Edges.Add("g", "h").SetMultilineStyle(new DotMulticolor(Color.Red, Color.Black, Color.Green));

        Snapshot.Match(graph.ToDot(), "multiline_edges");
    }

    [Fact]
    public void sets_multiline_style_on_edge_collections()
    {
        var graph = new DotGraph();

        graph.Edges.Style.SetMultilineStyle(4);
        graph.Subsections.Add().Edges.Style.SetMultilineStyle(4, Color.Red);
        graph.Subsections.Add().Edges.Style.SetMultilineStyle(Color.Red, Color.Black, Color.Green);
        graph.Subsections.Add().Edges.Style.SetMultilineStyle(new DotMulticolor(Color.Red, Color.Black, Color.Green));

        Snapshot.Match(graph.ToDot(), "multiline_edge_collections");
    }
}