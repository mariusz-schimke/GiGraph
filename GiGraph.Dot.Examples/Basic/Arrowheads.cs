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
                edge.Attributes.ArrowDirection = DotArrowDirection.Both;
                edge.Attributes.ArrowTail = DotArrowheadShape.Diamond;
                edge.Attributes.ArrowHead = DotArrowheadShape.Crow;
            });

            // some arrowhead combinations 
            graph.Edges.Add("Foo", "Bar").Attributes.ArrowHead = new DotArrowhead(DotArrowheadShape.Normal, isFilled: false);
            graph.Edges.Add("Foo", "Bar").Attributes.ArrowHead = new DotArrowhead(DotArrowheadShape.Normal, DotArrowheadParts.Left);
            graph.Edges.Add("Foo", "Bar").Attributes.ArrowHead = new DotArrowhead(DotArrowheadShape.Normal, isFilled: false, DotArrowheadParts.Right);

            // an arrowhead composed of multiple arrowheads
            graph.Edges.Add("Foo", "Bar").Attributes.ArrowHead = new DotCompositeArrowhead
            (
                DotArrowheadShape.Tee,
                DotArrowheadShape.None, // may be used as a separator
                new DotArrowhead(DotArrowheadShape.Diamond, isFilled: false, DotArrowheadParts.Left)
            );

            return graph;
        }
    }
}