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

        Assert.False(graph.Style.HasDefaultStyleModifiers());
        Assert.False(graph.Clusters.Style.HasDefaultStyleModifiers());

        graph.Clusters.Style.SetStyleModifiers(new DotClusterStyleModifiers(
            DotClusterFillStyle.Striped,
            DotBorderStyle.Dotted,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true
        ));

        Snapshot.Match(graph.ToDotString(), snapshotName);

        graph.Style.RestoreDefaultStyleModifiers();
        Assert.True(graph.Style.HasDefaultStyleModifiers());
        Assert.True(graph.Clusters.Style.HasDefaultStyleModifiers());

        // set the same another way
        graph.Clusters.Style.SetStyleModifiers(
            DotClusterFillStyle.Radial, // this one is shared with one directly on the graph (see below)
            DotBorderStyle.Dotted,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true
        );

        graph.Style.SetStyleModifiers(new DotGraphStyleModifiers(
            DotClusterFillStyle.Striped // overwrites the one set on the clusters above
        ));

        Snapshot.Match(graph.ToDotString(), snapshotName);

        graph.Clusters.Style.RestoreDefaultStyleModifiers();
        Assert.True(graph.Style.HasDefaultStyleModifiers());
        Assert.True(graph.Clusters.Style.HasDefaultStyleModifiers());
    }
}