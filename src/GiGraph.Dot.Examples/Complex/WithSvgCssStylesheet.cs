using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Graphs;

namespace GiGraph.Dot.Examples.Complex;

public static class WithSvgCssStylesheet
{
    [Pure]
    public static DotGraph Generate()
    {
        var graph = new DotGraph
        {
            SvgStyleSheet =
            {
                Url = Path.GetFullPath("stylesheet.css")
            }
        };

        graph.Nodes.Add("foo").SvgStyleSheet.Class = "foo_node";
        graph.Edges.Add("foo", "bar");

        return graph;
    }
}