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
    public void throws_when_no_weighted_color_is_specified_for_segmented_style()
    {
        var graph = new DotGraph();
        var edge = graph.Edges.Add("a", "b");

        Assert.Throws<ArgumentException>(() => edge.Style.SetSegmentedStyle(Color.Red));
        Assert.Throws<ArgumentException>(() => edge.Style.SetSegmentedStyle(new DotMulticolor(Color.Red)));
    }

    [Fact]
    public void sets_segmented_style_on_edges()
    {
        var graph = new DotGraph();

        graph.Edges
            .Add("a", "b")
            .Style
            .SetSegmentedStyle(Color.Red, Color.Black, new DotWeightedColor(Color.Green, 0.5));

        graph.Edges
            .Add("c", "d")
            .Style
            .SetSegmentedStyle(new DotMulticolor(Color.Red, Color.Black, new DotWeightedColor(Color.Green, 0.5)));

        Snapshot.Match(graph.ToDot(), "segmented_edges");
    }

    [Fact]
    public void sets_segmented_style_on_edge_collections()
    {
        var graph = new DotGraph();

        graph.Subsections
            .Add()
            .Edges
            .Style
            .SetSegmentedStyle(Color.Red, Color.Black, new DotWeightedColor(Color.Green, 0.5));

        graph.Subsections
            .Add()
            .Edges
            .Style
            .SetSegmentedStyle(new DotMulticolor(Color.Red, Color.Black, new DotWeightedColor(Color.Green, 0.5)));

        Snapshot.Match(graph.ToDot(), "segmented_edge_collections");
    }
}