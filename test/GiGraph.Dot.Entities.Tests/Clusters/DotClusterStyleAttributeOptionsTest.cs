using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Clusters;
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
        cluster.Style.SetOptions(new DotClusterStyleOptions(
            DotClusterFillStyle.Striped,
            DotBorderStyle.Dotted,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true
        ));

        Snapshot.Match(graph.Build(), snapshotName);

        cluster.Style.RestoreDefaultStyleFlags();

        // set the same another way
        cluster.Style.SetOptions(
            DotClusterFillStyle.Striped,
            DotBorderStyle.Dotted,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true
        );

        Snapshot.Match(graph.Build(), snapshotName);
    }
}