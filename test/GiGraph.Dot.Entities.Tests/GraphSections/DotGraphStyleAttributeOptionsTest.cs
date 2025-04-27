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
                DotGraphFillStyle.Striped
            )
        );

        Assert.False(graph.Style.HasDefaultStyleOptions());
        Assert.False(graph.Clusters.Style.HasDefaultStyleOptions());

        graph.Clusters.Style.SetStyleOptions(
            new DotClusterStyleOptions(
                DotGraphFillStyle.Striped,
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
            DotGraphFillStyle.Radial, // this one is shared with one directly on the graph (see below)
            DotBorderStyle.Dotted,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true
        );

        graph.Style.SetStyleOptions(
            new DotGraphStyleOptions(
                DotGraphFillStyle.Striped // overwrites the one set on the clusters above
            )
        );

        Snapshot.Match(graph.ToDot(), snapshotName);

        graph.Clusters.Style.SetDefaultStyleOptions();
        Assert.True(graph.Style.HasDefaultStyleOptions());
        Assert.True(graph.Clusters.Style.HasDefaultStyleOptions());
    }

    [Fact]
    public void nullifying_last_style_option_nullifies_style()
    {
        var graph = new DotGraph();

        Assert.False(graph.Style.HasStyleOptions());

        graph.Style.FillStyle = DotGraphFillStyle.Radial;

        Assert.True(graph.Style.HasStyleOptions());
        Assert.False(graph.Style.HasDefaultStyleOptions());

        graph.Style.FillStyle = DotGraphFillStyle.None;

        Assert.True(graph.Style.HasStyleOptions());
        Assert.True(graph.Style.HasDefaultStyleOptions());

        graph.Style.FillStyle = null;
        Assert.False(graph.Style.HasStyleOptions());
    }

    [Fact]
    public void nullifying_clusters_style_options_does_not_nullify_graph_style()
    {
        var graph = new DotGraph
        {
            Style =
            {
                FillStyle = DotGraphFillStyle.Radial
            }
        };

        graph.Clusters.Style.SetStyleOptions(
            new DotClusterStyleOptions(
                DotGraphFillStyle.Striped,
                DotBorderStyle.Dotted,
                DotBorderWeight.Bold,
                DotCornerStyle.Rounded,
                true
            )
        );

        Assert.True(graph.Style.HasStyleOptions());
        Assert.False(graph.Style.HasDefaultStyleOptions());

        Assert.True(graph.Clusters.Style.HasStyleOptions());
        Assert.False(graph.Clusters.Style.HasDefaultStyleOptions());

        graph.Clusters.Style.BorderStyle = null;
        graph.Clusters.Style.BorderWeight = null;
        graph.Clusters.Style.CornerStyle = null;
        graph.Clusters.Style.Invisible = null;

        Assert.True(graph.Style.HasStyleOptions());
        Assert.False(graph.Style.HasDefaultStyleOptions());

        Assert.True(graph.Clusters.Style.HasStyleOptions());
        Assert.False(graph.Clusters.Style.HasDefaultStyleOptions());

        graph.Style.FillStyle = null;
        Assert.False(graph.Style.HasStyleOptions());
    }

    [Fact]
    public void when_style_is_default_all_options_are_default()
    {
        var graph = new DotGraph();

        Assert.False(graph.Style.HasStyleOptions());

        graph.Style.SetDefaultStyleOptions();
        Assert.Equal(graph.Style.FillStyle, DotGraphFillStyle.None);

        Assert.Equal(graph.Clusters.Style.FillStyle, DotGraphFillStyle.None);
        Assert.Equal(graph.Clusters.Style.BorderStyle, DotBorderStyle.Default);
        Assert.Equal(graph.Clusters.Style.BorderWeight, DotBorderWeight.Default);
        Assert.Equal(graph.Clusters.Style.Invisible, false);

        graph.Style.ClearStyleOptions();
        Assert.Null(graph.Style.FillStyle);

        Assert.Null(graph.Clusters.Style.FillStyle);
        Assert.Null(graph.Clusters.Style.BorderStyle);
        Assert.Null(graph.Clusters.Style.BorderWeight);
        Assert.Null(graph.Clusters.Style.Invisible);


        graph.Style.SetDefaultStyleOptions();
        Assert.Equal(graph.Style.FillStyle, DotGraphFillStyle.None);

        graph.Clusters.Style.ClearStyleOptions();
        Assert.Null(graph.Style.FillStyle);
    }
}