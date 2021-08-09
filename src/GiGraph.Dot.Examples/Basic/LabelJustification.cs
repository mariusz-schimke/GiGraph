using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Nodes;

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
                attrs.Size.Width = 3;

                // using text formatter
                attrs.Label = new DotFormattedTextBuilder()
                   .AppendLine("Centered line")
                   .AppendLeftJustifiedLine("Left-justified line")
                   .AppendRightJustifiedLine("Right-justified line")
                   .Build();

                // using string concatenation
                attrs.Label = "Centered line" + DotEscapeString.LineBreak +
                    DotEscapeString.JustifyLeft("Left-justified line") +
                    DotEscapeString.JustifyRight("Right-justified line");
            });

            return graph;
        }
    }
}