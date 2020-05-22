using GiGraph.Dot.Entities.Graphs;

namespace GiGraph.Examples
{
    public static class HelloWorld
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph(isDirected: true);
            graph.Edges.Add("Hello", "World!");

            return graph;
        }
    }
}
