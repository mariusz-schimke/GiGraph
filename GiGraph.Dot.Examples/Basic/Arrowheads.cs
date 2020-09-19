using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Arrows;

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
                edge.Attributes.ArrowDirections = DotArrowDirections.Both;

                edge.Attributes.Tail.Arrow = DotArrowheadShape.Diamond;
                edge.Attributes.Head.Arrow = DotArrowheadShape.Crow;
            });

            // some basic arrowhead combinations 
            graph.Edges.Add("Foo", "Bar").Attributes.Head.Arrow = DotArrowhead.Empty();
            graph.Edges.Add("Foo", "Bar").Attributes.Head.Arrow = DotArrowhead.Empty(DotArrowheadParts.Right);
            graph.Edges.Add("Foo", "Bar").Attributes.Head.Arrow = DotArrowhead.Filled(DotArrowheadParts.Left);

            // a composition of multiple arrowheads
            graph.Edges.Add("Foo", "Bar").Attributes.Head.Arrow = new DotCompositeArrowhead
            (
                DotArrowheadShape.Tee,
                DotArrowheadShape.None, // may be used as a separator
                DotArrowhead.Empty(DotArrowheadShape.Diamond, DotArrowheadParts.Left)
            );

            return graph;
        }
    }
}