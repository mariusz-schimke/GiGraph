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

        graph.Style.SetStyleOptions(new DotGraphStyleOptions(
            DotGraphFillStyle.Striped
        ));

        Assert.False(graph.Style.HasDefaultStyleOptions());
        Assert.False(graph.Clusters.Style.HasDefaultStyleOptions());

        graph.Clusters.Style.SetStyleOptions(new DotClusterStyleOptions(
            DotGraphFillStyle.Striped,
            DotBorderStyle.Dotted,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true
        ));

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

        graph.Style.SetStyleOptions(new DotGraphStyleOptions(
            DotGraphFillStyle.Striped // overwrites the one set on the clusters above
        ));

        Snapshot.Match(graph.ToDot(), snapshotName);

        graph.Clusters.Style.SetDefaultStyleOptions();
        Assert.True(graph.Style.HasDefaultStyleOptions());
        Assert.True(graph.Clusters.Style.HasDefaultStyleOptions());
    }
}