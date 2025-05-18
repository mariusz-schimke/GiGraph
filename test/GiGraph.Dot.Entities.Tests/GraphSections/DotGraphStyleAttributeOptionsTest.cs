using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Clusters.Style;
using GiGraph.Dot.Types.Graphs.Style;
using GiGraph.Dot.Types.Styling;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.GraphSections;

public class DotGraphStyleAttributeOptionsTest
{
    [Fact]
    public void all_style_properties_are_specified()
    {
        const string snapshotName = "styled_graph";
        var graph = new DotGraph();

        graph.Style.SetStyleOptions(
            new DotGraphStyleOptions(
                DotClusterFillStyle.Striped
            )
        );

        Assert.False(graph.Style.HasDefaultStyleOptions());
        Assert.False(graph.Clusters.Style.HasDefaultStyleOptions());

        graph.Clusters.Style.SetStyleOptions(
            new DotClusterStyleOptions(
                DotClusterFillStyle.Striped,
                DotBorderStyle.Dotted,
                DotBorderWeight.Bold,
                DotCornerStyle.Rounded,
                true
            )
        );

        Snapshot.Match(graph.ToDot(), snapshotName);

        graph.Style.SetDefaultStyleOptions();
        Assert.True(graph.Style.HasDefaultStyleOptions());
        Assert.True(graph.Clusters.Style.HasDefaultStyleOptions());

        // set the same another way
        graph.Clusters.Style.SetStyleOptions(
            DotClusterFillStyle.Radial, // this one is shared with one directly on the graph (see below)
            DotBorderStyle.Dotted,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true
        );

        graph.Style.SetStyleOptions(
            new DotGraphStyleOptions(
                DotClusterFillStyle.Striped // overwrites the one set on the clusters above
            )
        );

        Snapshot.Match(graph.ToDot(), snapshotName);

        graph.Clusters.Style.SetDefaultStyleOptions();
        Assert.True(graph.Style.HasDefaultStyleOptions());
        Assert.True(graph.Clusters.Style.HasDefaultStyleOptions());
    }

    [Fact]
    public void setting_any_single_option_default_sets_default_style()
    {
        var graph = new DotGraph();

        Assert.False(graph.Style.HasStyleOptions());

        graph.Style.FillStyle = DotClusterFillStyle.None;

        Assert.True(graph.Style.HasStyleOptions());
        Assert.True(graph.Style.HasDefaultStyleOptions());
    }

    [Fact]
    public void when_style_is_default_all_options_are_default()
    {
        var graph = new DotGraph();

        Assert.False(graph.Style.HasStyleOptions());

        graph.Style.SetDefaultStyleOptions();
        Assert.Equal(DotClusterFillStyle.None, graph.Style.FillStyle);

        Assert.Equal(DotClusterFillStyle.None, graph.Clusters.Style.FillStyle);
        Assert.Equal(DotBorderStyle.Default, graph.Clusters.Style.BorderStyle);
        Assert.Equal(DotBorderWeight.Normal, graph.Clusters.Style.BorderWeight);
        Assert.False(graph.Clusters.Style.Invisible);

        graph.Style.RemoveStyleOptions();
        Assert.Equal(DotClusterFillStyle.None, graph.Style.FillStyle);

        Assert.Equal(DotClusterFillStyle.None, graph.Clusters.Style.FillStyle);
        Assert.Equal(DotBorderStyle.Default, graph.Clusters.Style.BorderStyle);
        Assert.Equal(DotBorderWeight.Normal, graph.Clusters.Style.BorderWeight);
        Assert.False(graph.Clusters.Style.Invisible);


        graph.Style.SetDefaultStyleOptions();
        Assert.Equal(DotClusterFillStyle.None, graph.Style.FillStyle);

        graph.Clusters.Style.RemoveStyleOptions();
        Assert.Equal(DotClusterFillStyle.None, graph.Style.FillStyle);
    }
}