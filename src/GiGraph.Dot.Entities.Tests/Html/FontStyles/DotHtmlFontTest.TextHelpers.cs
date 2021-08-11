using System.Drawing;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Output;
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
            var entity = DotHtmlFont.WithText("text");

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_font_with_no_attributes"
            );
        }

        [Fact]
        public void text_is_embedded_in_font_tag_only_with_all_set_attributes()
        {
            var entity = DotHtmlFont.WithText("text", "Arial", 20, Color.Blue);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_font_arial_20_blue"
            );
        }

        [Fact]
        public void text_is_embedded_in_font_tag_only_with_all_set_attributes_and_style()
        {
            var font = new DotStyledFont("Arial", 20, Color.Blue, DotFontStyles.Overline | DotFontStyles.Subscript);

            var entity1 = DotHtmlFont.WithText("text", font);
            var entity2 = DotHtmlFont.WithText("text", font.Name, font.Size, font.Color, font.Style);

            Assert.Equal((string) entity1.ToHtml(), entity2.ToHtml());

            Snapshot.Match(
                ((IDotHtmlEncodable) entity1).ToHtml(_syntaxOptions, _syntaxRules),
                "html_font_arial_20_blue_overline_subscript"
            );
        }
    }
}