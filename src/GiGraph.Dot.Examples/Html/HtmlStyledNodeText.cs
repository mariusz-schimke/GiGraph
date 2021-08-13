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
                   .AppendStyledText("Foo", new DotStyledFont(DotFontStyles.Bold, 20, Color.Brown))
                   .AppendText(" ")
                   .AppendText("Bar", new DotFont(20))
                   .AppendLine()
                   .AppendStyledText("Baz", new DotStyledFont(DotFontStyles.Italic | DotFontStyles.Underline, 14))
                   .Build();
            });

            return graph;
        }
    }
}