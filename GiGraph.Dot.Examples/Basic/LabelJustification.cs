using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Examples.Basic
{
    public static class LabelJustification
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();

            // node label with the ID of the node
            graph.Nodes.Add("Foo", attrs =>
            {
                attrs.Shape = DotNodeShape.Box;
                attrs.Width = 3;

                // using text formatter
                attrs.Label = new DotTextFormatter()
                   .AppendLine("Centered line")
                   .AppendLineLeftJustified("Left-justified line")
                   .AppendLineRightJustified("Right-justified line")
                   .ToFormattedText();

                // using string concatenation
                attrs.Label = "Centered line" + DotEscapeString.LineBreak +
                              DotEscapeString.JustifyLeft("Left-justified line") +
                              DotEscapeString.JustifyRight("Right-justified line");
            });

            return graph;
        }
    }
}