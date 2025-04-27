using System.Diagnostics.Contracts;
using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Types.Nodes.Style;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Examples.Complex;

public static class WithSubsections
{
    [Pure]
    public static DotGraph Generate()
    {
        var graph = new DotGraph();

        // the root section
        graph.Annotation = "the example graph (the root section)";

        graph.Nodes.Attributes.Annotation = "set default node color and style";
        graph.Nodes.Style.Color = Color.Orange;
        graph.Nodes.Style.FillStyle = DotNodeFillStyle.Normal;

        graph.Edges.Add("foo", "bar");

        // the subsections
        graph.Subsections.Add(subsection =>
        {
            subsection.Annotation = "subsection 1 - override node color";
            subsection.Nodes.Style.Color = Color.Turquoise;
            subsection.Edges.Add("baz", "qux");
        });

        graph.Subsections.Add(subsection =>
        {
            subsection.Annotation = "subsection 2 - set default edge style";
            subsection.Edges.Style.LineStyle = DotLineStyle.Dashed;
            subsection.Edges.Add("quux", "fred");
        });

        return graph;
    }
}