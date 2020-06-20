using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Records;

namespace GiGraph.Examples.Basic
{
    public static class HelloWorld
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph(isDirected: true);

            graph.NodeDefaults.Shape = DotShape.Record;

            // add an edge that connects the two specified nodes
            // (you don't have to add the nodes to the node collection of the graph
            // unless you need to specify some attributes for them)
            graph.Edges.Add("Hello", "World!").Attributes.Comment = "komentarz edge";

            graph.Nodes.Add("Node").Attributes.Label = "🙈";

            return graph;
        }
    }
}