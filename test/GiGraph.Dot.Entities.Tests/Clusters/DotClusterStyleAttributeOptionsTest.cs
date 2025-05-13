using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Clusters.Style;
using GiGraph.Dot.Types.Styling;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Clusters;

public class DotClusterStyleAttributeOptionsTest
{
    [Fact]
    public void all_style_properties_are_specified()
    {
        const string snapshotName = "styled_cluster";
        var graph = new DotGraph();
        var cluster = graph.Clusters.Add("c1");

        // set by class
        cluster.Style.SetStyleOptions(
            new DotClusterStyleOptions(
                DotClusterFillStyle.Striped,
                DotBorderStyle.Dotted,
                DotBorderWeight.Bold,
                DotCornerStyle.Rounded,
                true
            )
        );

        Snapshot.Match(graph.ToDot(), snapshotName);

        Assert.False(cluster.Style.HasDefaultStyleOptions());
        cluster.Style.SetDefaultStyleOptions();
        Assert.True(cluster.Style.HasDefaultStyleOptions());

        // set the same another way
        cluster.Style.SetStyleOptions(
            DotClusterFillStyle.Striped,
            DotBorderStyle.Dotted,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true
        );

        Snapshot.Match(graph.ToDot(), snapshotName);
    }

    [Fact]
    public void setting_any_single_option_default_sets_default_style()
    {
        var graph = new DotGraph();
        var cluster = graph.Clusters.Add("c1");

        Assert.False(cluster.Style.HasStyleOptions());

        cluster.Style.FillStyle = DotClusterFillStyle.None;

        Assert.True(cluster.Style.HasStyleOptions());
        Assert.True(cluster.Style.HasDefaultStyleOptions());

        cluster.Style.Invisible = false;
        Assert.True(cluster.Style.HasDefaultStyleOptions());
    }

    [Fact]
    public void when_style_is_default_all_options_are_default()
    {
        var graph = new DotGraph();
        var cluster = graph.Clusters.Add("c1");

        Assert.False(cluster.Style.HasStyleOptions());

        cluster.Style.SetDefaultStyleOptions();

        Assert.Equal(DotClusterFillStyle.None, cluster.Style.FillStyle);
        Assert.Equal(DotBorderStyle.Default, cluster.Style.BorderStyle);
        Assert.Equal(DotBorderWeight.Default, cluster.Style.BorderWeight);
        Assert.False(cluster.Style.Invisible);

        cluster.Style.ClearStyleOptions();

        Assert.Equal(DotClusterFillStyle.None, cluster.Style.FillStyle);
        Assert.Equal(DotBorderStyle.Default, cluster.Style.BorderStyle);
        Assert.Equal(DotBorderWeight.Default, cluster.Style.BorderWeight);
        Assert.False(cluster.Style.Invisible);
    }
}