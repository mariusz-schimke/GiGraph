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
            graph.Attributes.Label = new DotFormattedTextBuilder("Graph title: ")
               .AppendGraphId()
               .Build();

            // using string concatenation
            graph.Attributes.Label = "Graph title: " + DotEscapeString.GraphId;


            // -- node label example --

            graph.Nodes.Add("Foo", attrs =>
            {
                // using text formatter
                attrs.Label = new DotFormattedTextBuilder("Node ")
                   .AppendNodeId()
                   .Build();

                // using string concatenation
                attrs.Label = "Node " + DotEscapeString.NodeId;
            });


            // -- edge label example --

            // edge label with the IDs of the head and the tail nodes
            graph.Edges.Add("Foo", "Bar", edge =>
            {
                // using text formatter
                edge.Attributes.Label = new DotFormattedTextBuilder("From ")
                   .AppendTailNodeId()
                   .Append(" to ")
                   .AppendHeadNodeId()
                   .Build();

                // using string concatenation
                edge.Attributes.Label = "From " + DotEscapeString.TailNodeId +
                    " to " + DotEscapeString.HeadNodeId;
            });

            return graph;
        }
    }
}