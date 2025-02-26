using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Examples.Html;

public static class HtmlStyledNodeText
{
    public static DotGraph Generate()
    {
        var graph = new DotGraph();

        graph.Nodes.Add("Foo", node =>
        {
            node.Shape = DotNodeShape.Rectangle;

            node.Label = new DotHtmlBuilder()
                // appends a <font> element to the builder, with a custom size, color and style
                .AppendStyledFont(new DotStyledFont(DotFontStyles.Bold, 20, Color.RoyalBlue),
                    // specifies content of the parent <font> element
                    font => font
                        // appends any custom HTML
                        .AppendHtml("&bull; ")
                        // appends plain text and text embedded in another <font> tag with a color specified
                        .AppendText("Foo ").AppendText("Bar", new DotFont(Color.Black))
                )
                // appends a <br/> element
                .AppendLine()
                // appends text embedded in the <i> and <u> elements
                .AppendStyledText("Baz", DotFontStyles.Italic | DotFontStyles.Underline)
                // returns a type that may be assigned directly to a label
                .Build();
        });

        // an equivalent result with a manually composed HTML string
        graph.Nodes.Add("Foo", node =>
        {
            node.Shape = DotNodeShape.Rectangle;

            // the AsHtml() method just casts the string to DotHtmlString so that it is interpreted as HTML when the output script is generated
            node.Label = """<font color="royalblue" point-size="20"><b>&bull; Foo <font color="black">Bar</font></b></font><br/><i><u>Baz</u></i>""".AsHtml();
        });

        return graph;
    }
}