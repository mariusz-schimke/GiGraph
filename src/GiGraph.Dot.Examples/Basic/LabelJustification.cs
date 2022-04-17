using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Examples.Basic;

public static class LabelJustification
{
    public static DotGraph Generate()
    {
        var graph = new DotGraph();

        // node label with the ID of the node
        graph.Nodes.Add("Foo", node =>
        {
            node.Shape = DotNodeShape.Box;
            node.Size.Width = 3;

            // using text formatter
            node.Label = new DotFormattedTextBuilder()
               .AppendLine("Centered line")
               .AppendLeftJustifiedLine("Left-justified line")
               .AppendRightJustifiedLine("Right-justified line")
               .Build();

            // using string concatenation
            node.Label = "Centered line" + DotEscapeString.LineBreak +
                DotEscapeString.JustifyLeft("Left-justified line") +
                DotEscapeString.JustifyRight("Right-justified line");
        });

        return graph;
    }
}