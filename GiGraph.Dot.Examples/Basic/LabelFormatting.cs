using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Examples.Basic
{
    public static class LabelFormatting
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph("Label formatting");

            // -- graph label example --

            // using escape string builder
            graph.Attributes.Label = new DotEscapeStringBuilder("Graph title: ")
                                    .AppendGraphId()
                                    .ToEscapeString();

            // using string concatenation
            graph.Attributes.Label = "Graph title: " + DotEscapeString.GraphId;


            // -- node label example --

            graph.Nodes.Add("Foo", attrs =>
            {
                // using escape string builder
                attrs.Label = new DotEscapeStringBuilder("Node ")
                             .AppendNodeId()
                             .ToEscapeString();

                // using string concatenation
                attrs.Label = "Node " + DotEscapeString.NodeId;
            });


            // -- edge label example --

            // edge label with the IDs of the head and the tail nodes
            graph.Edges.Add("Foo", "Bar", edge =>
            {
                // using escape string builder
                edge.Attributes.Label = new DotEscapeStringBuilder("From ")
                                       .AppendEdgeTailNodeId()
                                       .Append(" to ")
                                       .AppendEdgeHeadNodeId()
                                       .ToEscapeString();

                // using string concatenation
                edge.Attributes.Label = "From " + DotEscapeString.EdgeTailNodeId +
                                        " to " + DotEscapeString.EdgeHeadNodeId;
            });

            return graph;
        }
    }
}