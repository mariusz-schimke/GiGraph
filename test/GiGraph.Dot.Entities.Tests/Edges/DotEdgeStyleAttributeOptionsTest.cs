using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Styling;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Edges;

public class DotEdgeStyleAttributeOptionsTest
{
    [Fact]
    public void all_style_properties_are_specified()
    {
        const string snapshotName = "styled_edge";
        var graph = new DotGraph();
        var edge = graph.Edges.Add("n1", "n2");

        // set by class
        edge.Style.SetStyleModifiers(new DotEdgeStyleModifiers(
            DotLineStyle.Dashed,
            DotLineWeight.Bold,
            true
        ));

        Snapshot.Match(graph.Build(), snapshotName);

        Assert.False(edge.Style.HasDefaultStyleModifiers());
        edge.Style.RestoreDefaultStyleModifiers();
        Assert.True(edge.Style.HasDefaultStyleModifiers());

        // set the same another way
        edge.Style.SetStyleModifiers(
            DotLineStyle.Dashed,
            DotLineWeight.Bold,
            true
        );

        Snapshot.Match(graph.Build(), snapshotName);
    }
}