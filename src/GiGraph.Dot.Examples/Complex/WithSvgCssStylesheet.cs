using System.IO;
using GiGraph.Dot.Entities.Graphs;

namespace GiGraph.Dot.Examples.Complex;

public static class WithSvgCssStylesheet
{
    public static DotGraph Generate()
    {
        var graph = new DotGraph();

        graph.SvgStyleSheet.Url = Path.GetFullPath("stylesheet.css");

        graph.Nodes.Add("foo").SvgStyleSheet.Class = "foo_node";
        graph.Edges.Add("foo", "bar");

        return graph;
    }
}