using System.Drawing;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Output;
using GiGraph.Dot.Types.Fonts;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.FontStyles
{
    public partial class DotHtmlFontStyleTest
    {
        [Fact]
        public void text_is_not_embedded_in_any_tag_for_no_font_params()
        {
            var entity = DotHtmlFont.StyleText("text");

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_font_no_params"
            );
        }

        [Fact]
        public void text_is_embedded_in_font_tag_only_with_all_set_attributes()
        {
            var entity = DotHtmlFont.StyleText("text", "Arial", 20, Color.Blue);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_font_arial_20_blue"
            );
        }

        [Fact]
        public void text_is_embedded_in_font_tag_only_with_all_set_attributes_and_style()
        {
            var entity = DotHtmlFont.StyleText("text", "Arial", 20, Color.Blue, DotFontStyles.Overline | DotFontStyles.Subscript);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_font_arial_20_blue_overline_subscript"
            );
        }
    }
}