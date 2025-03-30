using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Graphs;
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

        graph.Style.SetStyleModifiers(new DotGraphStyleModifiers(
            DotClusterFillStyle.Striped
        ));

        graph.Clusters.Style.SetStyleModifiers(new DotClusterStyleModifiers(
            DotClusterFillStyle.Striped,
            DotBorderStyle.Dotted,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true
        ));

        Snapshot.Match(graph.Build(), snapshotName);

        Assert.False(graph.Style.HasDefaultStyleModifiers());
        Assert.False(graph.Clusters.Style.HasDefaultStyleModifiers());
        graph.Style.RestoreDefaultStyleModifiers();
        Assert.True(graph.Style.HasDefaultStyleModifiers());
        Assert.True(graph.Clusters.Style.HasDefaultStyleModifiers());

        // set the same another way
        graph.Clusters.Style.SetStyleModifiers(
            DotClusterFillStyle.Striped,
            DotBorderStyle.Dotted,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true
        );

        Snapshot.Match(graph.Build(), snapshotName);
    }
}