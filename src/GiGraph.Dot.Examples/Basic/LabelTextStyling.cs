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
                        f => f.SetContent(c =>
                        {
                            c.AppendStyledText("Incididunt ut labore\n", style: DotFontStyles.Bold, color: Color.Blue)
                               .AppendStyledText("et dolore ", color: Color.Black, style: DotFontStyles.Normal)
                               .AppendStyledText("magna", color: Color.Red, style: DotFontStyles.Bold)
                               .AppendStyledText(" ", DotFontStyles.Normal)
                               .AppendStyledText("aliqua", style: DotFontStyles.Normal, color: Color.Black);
                        })
                    )
                   .Build();
            });

            graph.Edges.Add("Foo", "Bar", edge =>
            {
                // applies one font to all pieces of text, but each piece has a different style assigned
                edge.Attributes.Label = new DotHtmlBuilder()
                   .AppendFont(
                        new DotFont("Arial", 8, Color.Gray),
                        f => f.SetContent(c =>
                            {
                                c.AppendStyledText("Consectetur adipiscing elit,\n", DotFontStyles.Normal)
                                   .AppendStyledText("sed do eiusmod tempor", DotFontStyles.Italic | DotFontStyles.Underline);
                            }
                        ))
                   .Build();
            });

            return graph;
        }
    }
}