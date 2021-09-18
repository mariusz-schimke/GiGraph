using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Entities.Html.Font.Styles;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Fonts;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.FontStyles
{
    public partial class DotHtmlFontStyleTest
    {
        [Fact]
        public void text_is_not_embedded_in_any_tag_for_normal_style()
        {
            var entity = DotHtmlFontStyle.WithText("text", DotFontStyles.Normal);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_normal_text"
            );
        }

        [Fact]
        public void text_is_embedded_in_bold_tag()
        {
            var entity = DotHtmlFontStyle.WithText("text", DotFontStyles.Bold);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_bold_text"
            );
        }

        [Fact]
        public void text_is_embedded_in_bold_italic_tags()
        {
            var entity = DotHtmlFontStyle.WithText("text", DotFontStyles.Bold | DotFontStyles.Italic);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_bold_italic_text"
            );
        }

        [Fact]
        public void text_is_embedded_in_all_tags()
        {
            var entity = DotHtmlFontStyle.WithText(
                "text",
                DotFontStyles.Bold | DotFontStyles.Italic | DotFontStyles.Underline | DotFontStyles.Overline |
                DotFontStyles.Subscript | DotFontStyles.Superscript | DotFontStyles.Strikethrough
            );

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_all_tags_text"
            );
        }

        [Fact]
        public void text_is_followed_by_line_break()
        {
            var entity = DotHtmlFontStyle.WithText("text\n", DotFontStyles.Bold, DotHorizontalAlignment.Center);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_bold_centered_line"
            );
        }
    }
}