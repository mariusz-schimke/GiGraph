using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Examples.Basic;

public static class LabelPlaceholders
{
    [Pure]
    public static DotGraph Generate()
    {
        var graph = new DotGraph("Label placeholders");

        // -- graph label example --

        // using text formatter
        graph.Label = new DotFormattedTextBuilder("Graph title: ")
            .AppendGraphIdPlaceholder()
            .Build();

        // using string concatenation
        graph.Label = "Graph title: " + DotEscapeString.GraphIdPlaceholder;


        // -- node label example --

        graph.Nodes.Add("Foo", node =>
        {
            // using text formatter
            node.Label = new DotFormattedTextBuilder("Node ")
                .AppendNodeIdPlaceholder()
                .Build();

            // using string concatenation
            node.Label = "Node " + DotEscapeString.NodeIdPlaceholder;
        });


        // -- edge label example --

        // edge label with the IDs of the head and the tail nodes
        graph.Edges.Add("Foo", "Bar", edge =>
        {
            // using text formatter
            edge.Label = new DotFormattedTextBuilder("From ")
                .AppendTailNodeIdPlaceholder()
                .Append(" to ")
                .AppendHeadNodeIdPlaceholder()
                .Build();

            // using string concatenation
            edge.Label = "From " + DotEscapeString.TailNodeIdPlaceholder +
                " to " + DotEscapeString.HeadNodeIdPlaceholder;
        });

        return graph;
    }
}