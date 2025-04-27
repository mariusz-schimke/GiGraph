using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Edges.Style;
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

        // set by class
        edge.Style.SetStyleOptions(
            new DotEdgeStyleOptions(
                DotLineStyle.Dashed,
                DotLineWeight.Bold,
                true
            )
        );

        Snapshot.Match(graph.ToDot(), snapshotName);

        Assert.False(edge.Style.HasDefaultStyleOptions());
        edge.Style.SetDefaultStyleOptions();
        Assert.True(edge.Style.HasDefaultStyleOptions());

        // set the same another way
        edge.Style.SetStyleOptions(
            DotLineStyle.Dashed,
            DotLineWeight.Bold,
            true
        );

        Snapshot.Match(graph.ToDot(), snapshotName);
    }

    [Fact]
    public void nullifying_last_style_option_nullifies_style()
    {
        var graph = new DotGraph();
        var edge = graph.Edges.Add("n1", "n2");

        Assert.False(edge.Style.HasStyleOptions());

        edge.Style.SetStyleOptions(
            new DotEdgeStyleOptions(
                DotLineStyle.Dashed,
                DotLineWeight.Bold,
                true
            )
        );

        Assert.True(edge.Style.HasStyleOptions());
        Assert.False(edge.Style.HasDefaultStyleOptions());

        edge.Style.LineStyle = null;
        edge.Style.Invisible = null;

        Assert.True(edge.Style.HasStyleOptions());
        Assert.False(edge.Style.HasDefaultStyleOptions());

        edge.Style.LineWeight = DotLineWeight.Default;
        Assert.True(edge.Style.HasDefaultStyleOptions());

        edge.Style.LineWeight = null;
        Assert.False(edge.Style.HasStyleOptions());
    }
}