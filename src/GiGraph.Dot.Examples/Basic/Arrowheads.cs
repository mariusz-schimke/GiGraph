using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Examples.Basic
{
    public static class Arrowheads
    {
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
            graph.Edges.Add("Foo", "Bar").Head.Arrowhead = DotArrowhead.Empty();
            graph.Edges.Add("Foo", "Bar").Head.Arrowhead = DotArrowhead.Empty(DotArrowheadParts.Right);
            graph.Edges.Add("Foo", "Bar").Head.Arrowhead = DotArrowhead.Filled(DotArrowheadParts.Left);

            // a composition of multiple arrowheads
            graph.Edges.Add("Foo", "Bar").Head.Arrowhead = new DotCompositeArrowhead
            (
                DotArrowheadShape.Tee,
                DotArrowheadShape.None, // may be used as a separator
                DotArrowhead.Empty(DotArrowheadShape.Diamond, DotArrowheadParts.Left)
            );

            return graph;
        }
    }
}