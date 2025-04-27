using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Nodes.Style;
using GiGraph.Dot.Types.Styling;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Nodes;

public class DotNodeStyleAttributeOptionsTest
{
    [Fact]
    public void all_style_properties_are_specified()
    {
        const string snapshotName = "styled_node";
        var graph = new DotGraph();
        var node = graph.Nodes.Add("n1");

        // set by class
        node.Style.SetStyleOptions(new DotNodeStyleOptions(
            DotNodeFillStyle.Radial,
            DotBorderStyle.Dashed,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true,
            true
        ));

        Snapshot.Match(graph.ToDot(), snapshotName);

        Assert.False(node.Style.HasDefaultStyleOptions());
        node.Style.SetDefaultStyleOptions();
        Assert.True(node.Style.HasDefaultStyleOptions());

        // set the same another way
        node.Style.SetStyleOptions(
            DotNodeFillStyle.Radial,
            DotBorderStyle.Dashed,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true,
            true
        );

        Snapshot.Match(graph.ToDot(), snapshotName);
    }
}