using System.Drawing;
using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Images;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Builder
{
    public class DotHtmlBuilderTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void html_builder_generates_valid_html_structure()
        {
            var builder = new DotHtmlBuilder();

            builder.Append(new DotHtmlFont())
               .AppendBoldText("bold\n", DotHorizontalAlignment.Left)
               .AppendBold(b => b.SetContent("bold"))
               .AppendItalicText("italic\n", DotHorizontalAlignment.Center)
               .AppendItalic(i => i.SetContent("italic"))
               .AppendUnderlineText("underline\n", DotHorizontalAlignment.Right)
               .AppendUnderline(u => u.SetContent("underline"))
               .AppendOverlineText("overline\n", DotHorizontalAlignment.Left)
               .AppendOverline(o => o.SetContent("overline"))
               .AppendSubscriptText("subscript\n", DotHorizontalAlignment.Center)
               .AppendSubscript(sb => sb.SetContent("subscript"))
               .AppendSuperscriptText("superscript\n", DotHorizontalAlignment.Right)
               .AppendSuperscript(sp => sp.SetContent("superscript"))
               .AppendStrikethroughText("strikethrough\n", DotHorizontalAlignment.Left)
               .AppendStrikethrough(st => st.SetContent("strikethrough"))
               .AppendText("text")
               .AppendText("text\n", DotHorizontalAlignment.Left)
               .AppendLine()
               .AppendLine(DotHorizontalAlignment.Center)
               .AppendLine("line of text")
               .AppendLine("right-justified line of text", DotHorizontalAlignment.Right)
               .AppendFont(f => f.SetContent("font 1"))
               .AppendFont(new DotFont("arial", 10, Color.Red), f => f.SetContent("font 2"))
               .AppendStyledFont(new DotStyledFont(), f => f.SetContent("styled text 1"))
               .AppendStyledFont(new DotStyledFont(DotFontStyles.Bold, "arial", 10, Color.Red), f => f.SetContent("styled text 2"))
               .AppendStyled(DotFontStyles.Bold, f => f.SetContent("bold text"))
               .AppendStyled(DotFontStyles.Normal, f => f.SetContent("normal text"))
               .AppendStyledText("styled text 1\n", "arial", 10, Color.Red, DotFontStyles.Bold, DotHorizontalAlignment.Center)
               .AppendStyledText("styled text 2\n", new DotStyledFont(DotFontStyles.Bold, "arial", 10, Color.Red), DotHorizontalAlignment.Left)
               .AppendStyledText("font\n", new DotFont("arial", 10, Color.Red), DotHorizontalAlignment.Left)
               .AppendStyledText("bold text 1\n", DotFontStyles.Bold, DotHorizontalAlignment.Right)
               .AppendImage("image.png", DotImageScaling.None)
               .AppendImage("image.png", init: e => e.Scaling = DotImageScaling.Uniform)
               .AppendTable(t => t.AddRow(r => r.AddCell("cell")))
               .AppendHorizontalRule()
               .AppendHorizontalRule(e => e.Attributes.Set("attr", 5))
               .AppendVerticalRule()
               .AppendVerticalRule(e => e.Attributes.Set("attr", 5))
               .AppendHtml("<custom-html></custom-html>")
               .AppendElement("custom-element", e => e.SetContent("content"))
               .AppendVoidElement("custom-void-element", e => e.Attributes.Set("attr", 5))
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

            builder.AppendBold(b => b.SetContent(c =>
            {
                c.AppendItalic(i => i.SetContent("bold italic"));
            }));

            Snapshot.Match(
                ((IDotHtmlEncodable) builder.Build()).ToHtml(_syntaxOptions, _syntaxRules),
                "html_from_nested_builder"
            );
        }
    }
}