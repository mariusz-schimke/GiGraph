using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Edges.Arrowheads;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Edges;

public class DotEdgeEndpointArrowheadSettersTest
{
    [Fact]
    public void sets_arrowhead_variants()
    {
        var graph = new DotGraph();

        graph.Edges.Head.SetArrowhead(DotArrowheadShape.Dot, filled: true, DotArrowheadParts.Right);
        graph.Edges.Tail.SetEmptyArrowhead(DotArrowheadShape.Diamond, DotArrowheadParts.Left);

        graph.Edges.Add("node1", "node2")
            .Head.SetArrowhead(DotArrowheadShape.Crow, filled: false, DotArrowheadParts.Left);

        graph.Edges
            .Add("node3", "node4")
            .Tail.SetCompositeArrowhead(DotArrowheadShape.Crow, DotArrowheadShape.Box);

        graph.Edges
            .Add("node5", "node6")
            .Tail.SetCompositeArrowhead(new DotArrowhead(DotArrowheadShape.Tee, filled: true, DotArrowheadParts.Right));

        Snapshot.Match(graph.ToDot(), "edge_endpoints_arrowheads");
    }
}