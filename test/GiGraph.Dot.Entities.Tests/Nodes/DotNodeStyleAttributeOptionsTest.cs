using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Nodes;
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
        node.Style.SetOptions(new DotNodeStyleOptions(
            DotNodeFillStyle.Radial,
            DotBorderStyle.Dashed,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true,
            true
        ));

        Snapshot.Match(graph.Build(), snapshotName);

        node.Style.RestoreDefaultStyleFlags();

        // set the same another way
        node.Style.SetOptions(
            DotNodeFillStyle.Radial,
            DotBorderStyle.Dashed,
            DotBorderWeight.Bold,
            DotCornerStyle.Rounded,
            true,
            true
        );

        Snapshot.Match(graph.Build(), snapshotName);
    }
}