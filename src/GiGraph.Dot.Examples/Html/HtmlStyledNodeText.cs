using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Examples.Html
{
    public static class HtmlStyledNodeText
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();

            graph.Nodes.Add("Foo", attrs =>
            {
                attrs.Shape = DotNodeShape.Rectangle;

                attrs.Label = new DotHtmlBuilder()
                   .AppendStyledFont(new DotStyledFont(DotFontStyles.Bold, 20, Color.Brown), font => font
                       .AppendHtml("&bull; ").AppendText("Foo ").AppendText("Bar", new DotFont(Color.Black))
                    )
                   .AppendLine()
                   .AppendStyledText("Baz", DotFontStyles.Italic | DotFontStyles.Underline)
                   .Build();
            });

            return graph;
        }
    }
}