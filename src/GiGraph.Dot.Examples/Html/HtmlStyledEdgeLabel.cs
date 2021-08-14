using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Examples.Html
{
    public static class HtmlStyledEdgeLabel
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();

            graph.Edges.Add("Foo", "Bar", edge =>
            {
                // applies one font to all pieces of text, but each piece has a different style assigned
                edge.Attributes.Label = new DotHtmlBuilder()
                   .AppendFont(
                        new DotFont("Arial", 8, Color.Gray),
                        f => f
                           .AppendStyledText("Lorem ipsum dolor sit amet,\n", DotFontStyles.Normal)
                           .AppendStyledText("consectetur adipiscing elit", DotFontStyles.Italic | DotFontStyles.Underline)
                    )
                   .Build();
            });

            return graph;
        }
    }
}