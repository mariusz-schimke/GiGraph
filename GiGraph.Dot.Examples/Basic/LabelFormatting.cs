using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Examples.Basic
{
    public static class LabelFormatting
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph("Label formatting");

            // graph label with the ID of the graph
            graph.Attributes.Label = new DotEscapeStringBuilder("Graph label: ")
                                    .AppendGraphId()
                                    .ToEscapeString();

            // or an alternative way
            graph.Attributes.Label = "Graph label: " + DotEscapeString.GraphId;


            // node label with the ID of the node
            graph.Nodes.Add("Foo", attrs =>
            {
                attrs.Label = new DotEscapeStringBuilder("Node ")
                             .AppendNodeId()
                             .ToEscapeString();

                // or an alternative way
                attrs.Label = "Node " + DotEscapeString.NodeId;
            });


            // edge label with the IDs of the head and the tail nodes
            graph.Edges.Add("Foo", "Bar", edge =>
            {
                edge.Attributes.Label = new DotEscapeStringBuilder("From ")
                                       .AppendEdgeTailNodeId()
                                       .Append(" to ")
                                       .AppendEdgeHeadNodeId()
                                       .ToEscapeString();

                // or an alternative way
                edge.Attributes.Label = "From " + DotEscapeString.EdgeTailNodeId +
                                        " to " + DotEscapeString.EdgeHeadNodeId;
            });

            return graph;
        }
    }
}