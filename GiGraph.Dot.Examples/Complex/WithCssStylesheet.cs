using System.IO;
using GiGraph.Dot.Entities.Graphs;

namespace GiGraph.Dot.Examples.Complex
{
    public static class WithCssStylesheet
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();

            graph.Attributes.Collection.Set("stylesheet", Path.GetFullPath("stylesheet.css"));

            graph.Nodes.Add("foo").Attributes.Collection.Set("class", "foo_node");
            graph.Edges.Add("foo", "bar");

            return graph;
        }
    }
}