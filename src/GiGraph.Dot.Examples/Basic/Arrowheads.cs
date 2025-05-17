using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Edges.Arrowheads;

namespace GiGraph.Dot.Examples.Basic;

public static class Arrowheads
{
    [Pure]
    public static DotGraph Generate()
    {
        var graph = new DotGraph();

        // an edge with arrowheads on both sides
        graph.Edges.Add("Foo", "Bar", edge =>
        {
            edge.Directions = DotEdgeDirections.Both;

            edge.Tail.Arrowhead = DotArrowheadShape.Diamond;
            edge.Head.Arrowhead = DotArrowheadShape.Crow;
        });

        // some basic arrowhead combinations
        graph.Edges.Add("Foo", "Bar").Head.Arrowhead = new DotArrowhead(DotArrowheadShape.Normal, filled: false, visibleParts: DotArrowheadParts.Both);
        graph.Edges.Add("Foo", "Bar").Head.Arrowhead = DotArrowhead.Empty(visibleParts: DotArrowheadParts.Right);
        graph.Edges.Add("Foo", "Bar").Head.SetArrowhead(visibleParts: DotArrowheadParts.Left);

        // a composition of multiple arrowheads
        graph.Edges.Add("Foo", "Bar").Head.Arrowhead = new DotCompositeArrowhead
        (
            DotArrowheadShape.Tee,
            DotArrowheadShape.None, // may be used as a separator
            DotArrowhead.Empty(DotArrowheadShape.Diamond, DotArrowheadParts.Left)
        );

        // or the same by a method
        graph.Edges.Add("Foo", "Bar").Head.SetCompositeArrowhead(
            DotArrowheadShape.Tee,
            DotArrowheadShape.None, // may be used as a separator
            DotArrowhead.Empty(DotArrowheadShape.Diamond, DotArrowheadParts.Left)
        );

        return graph;
    }
}