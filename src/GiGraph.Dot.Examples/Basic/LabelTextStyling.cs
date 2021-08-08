using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Html.Font;
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
                attrs.Label = DotHtmlFontStyle.SetStyles(
                    ("Lorem ipsum\n", DotFontStyles.Bold),
                    ("dolor sit amet", DotFontStyles.Normal)
                );
            });

            graph.Nodes.Add("Bar", attrs =>
            {
                // the pieces of text have different fonts and styles assigned with a common parent font applied to all
                attrs.Label = DotHtmlFont.SetFonts(
                    new DotStyledFont("Arial", 12, color: Color.Blue),
                    ("Incididunt ut labore\n", new DotStyledFont(style: DotFontStyles.Bold, color: Color.Blue)),
                    ("et dolore ", new DotStyledFont(style: DotFontStyles.Normal, color: Color.Black)),
                    ("magna", new DotStyledFont(style: DotFontStyles.Bold, color: Color.Red)),
                    (" ", new DotStyledFont(style: DotFontStyles.Normal)),
                    ("aliqua", new DotStyledFont(style: DotFontStyles.Normal, color: Color.Black))
                );
            });

            graph.Edges.Add("Foo", "Bar", edge =>
            {
                // applies one font to all pieces of text, but each piece has a different style assigned
                edge.Attributes.Label = DotHtmlFont.SetFont(
                    new DotStyledFont("Arial", 8, Color.Gray),
                    ("Consectetur adipiscing elit,\n", DotFontStyles.Normal),
                    ("sed do eiusmod tempor", DotFontStyles.Italic | DotFontStyles.Underline)
                );
            });

            return graph;
        }
    }
}