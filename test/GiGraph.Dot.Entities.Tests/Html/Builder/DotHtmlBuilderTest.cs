using System.Drawing;
using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Images;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Builder;

public class DotHtmlBuilderTest
{
    private readonly DotSyntaxOptions _syntaxOptions = new();
    private readonly DotSyntaxRules _syntaxRules = new();

    [Fact]
    public void html_builder_generates_valid_html_structure()
    {
        var builder = new DotHtmlBuilder();

        builder.Append(new DotHtmlFont())
            .AppendEntity(new DotHtmlFont(), f => f.Color = Color.Red)
            .AppendBoldText("bold\n", DotHorizontalAlignment.Left)
            .AppendBold(b => b.AppendText("bold"))
            .AppendItalicText("italic\n", DotHorizontalAlignment.Center)
            .AppendItalic(i => i.AppendText("italic"))
            .AppendUnderlineText("underline\n", DotHorizontalAlignment.Right)
            .AppendUnderline(u => u.AppendText("underline"))
            .AppendOverlineText("overline\n", DotHorizontalAlignment.Left)
            .AppendOverline(o => o.AppendText("overline"))
            .AppendSubscriptText("subscript\n", DotHorizontalAlignment.Center)
            .AppendSubscript(sb => sb.AppendText("subscript"))
            .AppendSuperscriptText("superscript\n", DotHorizontalAlignment.Right)
            .AppendSuperscript(sp => sp.AppendText("superscript"))
            .AppendStrikethroughText("strikethrough\n", DotHorizontalAlignment.Left)
            .AppendStrikethrough(st => st.AppendText("strikethrough"))
            .AppendText("text")
            .AppendText("text\n", DotHorizontalAlignment.Left)
            .AppendLine()
            .AppendLine(DotHorizontalAlignment.Center)
            .AppendLine("line of text")
            .AppendLine("right-justified line of text", DotHorizontalAlignment.Right)
            .AppendFont(f => f.AppendText("font"))
            .AppendFont(new DotFont("arial", 10, Color.Red), f => f.AppendText("font"))
            .AppendStyledFont(new DotStyledFont(), f => f.AppendText("styled text"))
            .AppendStyledFont(new DotStyledFont(DotFontStyles.Bold, "arial", 10, Color.Red), f => f.AppendText("styled text"))
            .AppendStyled(DotFontStyles.Bold, f => f.AppendText("bold text"))
            .AppendStyled(DotFontStyles.Normal, f => f.AppendText("normal text"))
            .AppendStyledText("styled text\n", new DotStyledFont(DotFontStyles.Bold, "arial", 10, Color.Red), DotHorizontalAlignment.Left)
            .AppendText("font\n", new DotFont("arial", 10, Color.Red), DotHorizontalAlignment.Left)
            .AppendStyledText("bold text 1\n", DotFontStyles.Bold, DotHorizontalAlignment.Right)
            .AppendImage("image.png", DotImageScaling.None)
            .AppendTable(t => t.AddRow(r => r.AddCell("cell")))
            .AppendHorizontalRule()
            .AppendVerticalRule()
            .AppendHtml("<custom-html></custom-html>")
            .AppendElement("custom-element", e => e.SetContent("content"))
            .AppendVoidElement("custom-void-element", e => e.Attributes.SetValue("attr", 5))
            .AppendComment("comment");

        Snapshot.Match(
            ((IDotHtmlEncodable) builder.Build()).ToHtml(_syntaxOptions, _syntaxRules),
            "html_from_builder"
        );
    }

    [Fact]
    public void html_builder_generates_valid_nested_html_structure()
    {
        var builder = new DotHtmlBuilder();

        builder.AppendBold(b =>
            b.AppendItalic(i =>
                i.AppendText("bold italic")
            )
        );

        Snapshot.Match(
            ((IDotHtmlEncodable) builder.Build()).ToHtml(_syntaxOptions, _syntaxRules),
            "html_from_nested_builder"
        );
    }
}