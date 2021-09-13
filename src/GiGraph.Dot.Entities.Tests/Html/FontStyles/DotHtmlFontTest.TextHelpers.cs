using System.Drawing;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.Fonts;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.FontStyles
{
    public partial class DotHtmlFontTest
    {
        [Fact]
        public void text_is_not_embedded_in_any_tag_for_no_font_params()
        {
            var font = new DotFont();
            var styledFont = new DotStyledFont(font);

            var entity1 = DotHtmlFont.WithText("text", font);
            var entity2 = DotHtmlFont.WithText("text", styledFont);

            Assert.Equal((string) entity1.ToHtml(), entity2.ToHtml());

            Snapshot.Match(
                ((IDotHtmlEncodable) entity1).ToHtml(_syntaxOptions, _syntaxRules),
                "html_font_with_no_attributes"
            );
        }

        [Fact]
        public void text_is_embedded_in_font_tag_only_with_all_set_attributes()
        {
            var font = new DotFont("Arial", 20, Color.Blue);
            var styledFont = new DotStyledFont(font);

            var entity1 = DotHtmlFont.WithText("text", font);
            var entity2 = DotHtmlFont.WithText("text", styledFont);

            Assert.Equal((string) entity1.ToHtml(), entity2.ToHtml());

            Snapshot.Match(
                ((IDotHtmlEncodable) entity1).ToHtml(_syntaxOptions, _syntaxRules),
                "html_font_arial_20_blue"
            );
        }

        [Fact]
        public void text_is_embedded_in_font_tag_only_with_all_set_attributes_and_style()
        {
            var font = new DotStyledFont(DotFontStyles.Overline | DotFontStyles.Subscript, "Arial", 20, Color.Blue);

            var entity = DotHtmlFont.WithText("text", font);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_font_arial_20_blue_overline_subscript"
            );
        }
    }
}