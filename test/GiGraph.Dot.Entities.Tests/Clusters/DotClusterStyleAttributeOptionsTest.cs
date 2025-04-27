using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Clusters.Style;
using GiGraph.Dot.Types.Graphs.Style;
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
        cluster.Style.SetStyleOptions(new DotClusterStyleOptions(
            DotGraphFillStyle.Striped,
            DotBorderStyle.Dotted,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true
        ));

        Snapshot.Match(graph.ToDot(), snapshotName);

        Assert.False(cluster.Style.HasDefaultStyleOptions());
        cluster.Style.SetDefaultStyleOptions();
        Assert.True(cluster.Style.HasDefaultStyleOptions());
        
        // set the same another way
        cluster.Style.SetStyleOptions(
            DotGraphFillStyle.Striped,
            DotBorderStyle.Dotted,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true
        );

        Snapshot.Match(graph.ToDot(), snapshotName);
    }
}