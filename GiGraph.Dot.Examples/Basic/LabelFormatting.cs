using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Examples.Basic
{
    public static class LabelFormatting
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph("Label formatting example", isDirected: true);

            graph.Attributes.Label = new DotEscapeStringBuilder()
                                    .AppendGraphId()
                                    .ToEscapeString();

            graph.Nodes.Add("Foo", attrs =>
            {
                attrs.Label = new DotEscapeStringBuilder("Node ")
                             .AppendNodeId()
                             .ToEscapeString();
            });

            graph.Edges.Add("Foo", "Bar", edge =>
            {
                edge.Attributes.Label = new DotEscapeStringBuilder("From ")
                                       .AppendEdgeTailNodeId()
                                       .Append(" to ")
                                       .AppendEdgeHeadNodeId()
                                       .ToEscapeString();
            });

            return graph;
        }
    }
}