using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Examples.Basic
{
    public static class LabelFormatting
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph("Label formatting");

            // -- graph label example --

            // using text formatter
            graph.Label = new DotFormattedTextBuilder("Graph title: ")
               .AppendGraphId()
               .Build();

            // using string concatenation
            graph.Label = "Graph title: " + DotEscapeString.GraphId;


            // -- node label example --

            graph.Nodes.Add("Foo", node =>
            {
                // using text formatter
                node.Label = new DotFormattedTextBuilder("Node ")
                   .AppendNodeId()
                   .Build();

                // using string concatenation
                node.Label = "Node " + DotEscapeString.NodeId;
            });


            // -- edge label example --

            // edge label with the IDs of the head and the tail nodes
            graph.Edges.Add("Foo", "Bar", edge =>
            {
                // using text formatter
                edge.Label = new DotFormattedTextBuilder("From ")
                   .AppendTailNodeId()
                   .Append(" to ")
                   .AppendHeadNodeId()
                   .Build();

                // using string concatenation
                edge.Label = "From " + DotEscapeString.TailNodeId +
                    " to " + DotEscapeString.HeadNodeId;
            });

            return graph;
        }
    }
}