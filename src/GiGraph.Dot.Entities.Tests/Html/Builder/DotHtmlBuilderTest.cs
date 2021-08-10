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

            builder.Append(new DotHtmlFont());

            builder.AppendBoldText("bold\n", DotHorizontalAlignment.Left);
            builder.AppendBold(b => b.SetContent("bold"));

            builder.AppendItalicText("italic\n", DotHorizontalAlignment.Center);
            builder.AppendItalic(i => i.SetContent("italic"));

            builder.AppendUnderlineText("underline\n", DotHorizontalAlignment.Right);
            builder.AppendUnderline(u => u.SetContent("underline"));

            builder.AppendOverlineText("overline\n", DotHorizontalAlignment.Left);
            builder.AppendOverline(o => o.SetContent("overline"));

            builder.AppendSubscriptText("subscript\n", DotHorizontalAlignment.Center);
            builder.AppendSubscript(sb => sb.SetContent("subscript"));

            builder.AppendSuperscriptText("superscript\n", DotHorizontalAlignment.Right);
            builder.AppendSuperscript(sp => sp.SetContent("superscript"));

            builder.AppendStrikethroughText("strikethrough\n", DotHorizontalAlignment.Left);
            builder.AppendStrikethrough(st => st.SetContent("strikethrough"));

            builder.AppendText("text");
            builder.AppendText("text\n", DotHorizontalAlignment.Left);

            builder.AppendLine();
            builder.AppendLine(DotHorizontalAlignment.Center);

            builder.AppendLine("line of text");
            builder.AppendLine("right-justified line of text", DotHorizontalAlignment.Right);

            builder.AppendFont(f => f.SetContent("font 1"));
            builder.AppendFont(new DotFont("arial", 10, Color.Red), f => f.SetContent("font 2"));

            builder.AppendStyledFont(new DotStyledFont(), f => f.SetContent("styled text 1"));
            builder.AppendStyledFont(new DotStyledFont("arial", 10, Color.Red, DotFontStyles.Bold), f => f.SetContent("styled text 2"));

            builder.AppendStyled(DotFontStyles.Bold, f => f.SetContent("bold text"));
            builder.AppendStyled(DotFontStyles.Normal, f => f.SetContent("normal text"));

            builder.AppendStyledText("styled text 1\n", "arial", 10, Color.Red, DotFontStyles.Bold, DotHorizontalAlignment.Center);
            builder.AppendStyledText("styled text 2\n", new DotStyledFont("arial", 10, Color.Red, DotFontStyles.Bold), DotHorizontalAlignment.Left);

            builder.AppendStyledText("font\n", new DotFont("arial", 10, Color.Red), DotHorizontalAlignment.Left);
            builder.AppendStyledText("bold text 1\n", DotFontStyles.Bold, DotHorizontalAlignment.Right);

            builder.AppendImage("image.png", DotImageScaling.None);
            builder.AppendImage("image.png", init: e => e.Scaling = DotImageScaling.Uniform);
            builder.AppendTable(t => t.AddRow(r => r.AddCell("cell")));

            builder.AppendHorizontalRule();
            builder.AppendHorizontalRule(e => e.Attributes.Set("attr", 5));

            builder.AppendVerticalRule();
            builder.AppendVerticalRule(e => e.Attributes.Set("attr", 5));

            builder.AppendHtml("<custom-html></custom-html>");

            builder.AppendElement("custom-element", e => e.SetContent("content"));
            builder.AppendVoidElement("custom-void-element", e => e.Attributes.Set("attr", 5));

            builder.AppendComment("comment");

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