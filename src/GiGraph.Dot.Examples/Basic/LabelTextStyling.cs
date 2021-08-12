using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Examples.Basic
{
    public static class LabelTextStyling
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();
            graph.Nodes.Attributes.Shape = DotNodeShape.Rectangle;

            graph.Nodes.Add("Foo", attrs =>
            {
                // the pieces of text have different font styles assigned
                attrs.Label = new DotHtmlBuilder()
                   .AppendBoldText("Lorem ipsum\n")
                   .AppendStyledText("dolor sit amet", DotFontStyles.Normal)
                   .Build();
            });

            graph.Nodes.Add("Bar", attrs =>
            {
                // the pieces of text have different fonts and styles assigned with a common parent font applied to all
                attrs.Label = new DotHtmlBuilder()
                   .AppendFont(
                        new DotFont("Arial", 12, Color.Blue),
                        f => f
                           .AppendStyledText("Incididunt ut labore\n", new DotStyledFont(DotFontStyles.Bold, Color.Blue))
                           .AppendStyledText("et dolore ", new DotStyledFont(DotFontStyles.Normal, Color.Black))
                           .AppendStyledText("magna", new DotStyledFont(style: DotFontStyles.Bold, Color.Red))
                           .AppendStyledText(" ", DotFontStyles.Normal)
                           .AppendStyledText("aliqua", new DotStyledFont(DotFontStyles.Normal, Color.Black))
                    )
                   .Build();
            });

            graph.Edges.Add("Foo", "Bar", edge =>
            {
                // applies one font to all pieces of text, but each piece has a different style assigned
                edge.Attributes.Label = new DotHtmlBuilder()
                   .AppendFont(
                        new DotFont("Arial", 8, Color.Gray),
                        f => f
                           .AppendStyledText("Consectetur adipiscing elit,\n", DotFontStyles.Normal)
                           .AppendStyledText("sed do eiusmod tempor", DotFontStyles.Italic | DotFontStyles.Underline)
                    )
                   .Build();
            });

            return graph;
        }
    }
}