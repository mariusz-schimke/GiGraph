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
    public void nullifying_last_style_option_nullifies_style()
    {
        var graph = new DotGraph();
        var cluster = graph.Clusters.Add("c1");

        Assert.False(cluster.Style.HasStyleOptions());

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

        Assert.True(cluster.Style.HasStyleOptions());
        Assert.False(cluster.Style.HasDefaultStyleOptions());

        cluster.Style.FillStyle = null;
        cluster.Style.BorderStyle = null;
        cluster.Style.BorderWeight = null;
        cluster.Style.Invisible = null;

        Assert.True(cluster.Style.HasStyleOptions());
        Assert.False(cluster.Style.HasDefaultStyleOptions());

        cluster.Style.CornerStyle = DotCornerStyle.Default;
        Assert.True(cluster.Style.HasDefaultStyleOptions());

        cluster.Style.CornerStyle = null;
        Assert.False(cluster.Style.HasStyleOptions());
    }

    [Fact]
    public void when_style_is_default_all_options_are_default()
    {
        var graph = new DotGraph();
        var cluster = graph.Clusters.Add("c1");

        Assert.False(cluster.Style.HasStyleOptions());

        cluster.Style.SetDefaultStyleOptions();

        Assert.Equal(cluster.Style.FillStyle, DotClusterFillStyle.None);
        Assert.Equal(cluster.Style.BorderStyle, DotBorderStyle.Default);
        Assert.Equal(cluster.Style.BorderWeight, DotBorderWeight.Default);
        Assert.Equal(cluster.Style.Invisible, false);

        cluster.Style.ClearStyleOptions();

        Assert.Null(cluster.Style.FillStyle);
        Assert.Null(cluster.Style.BorderStyle);
        Assert.Null(cluster.Style.BorderWeight);
        Assert.Null(cluster.Style.Invisible);
    }
}