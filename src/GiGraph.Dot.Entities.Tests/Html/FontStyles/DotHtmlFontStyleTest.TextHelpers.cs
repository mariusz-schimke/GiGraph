using GiGraph.Dot.Entities.Html;
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
        public void text_is_not_embedded_in_any_tag_for_normal_style()
        {
            var entity = DotHtmlFontStyle.SetStyle("text", DotFontStyles.Normal);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_normal_text"
            );
        }

        [Fact]
        public void text_is_embedded_in_bold_tag()
        {
            var entity = DotHtmlFontStyle.SetStyle("text", DotFontStyles.Bold);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_bold_text"
            );
        }

        [Fact]
        public void text_is_embedded_in_bold_italic_tags()
        {
            var entity = DotHtmlFontStyle.SetStyle("text", DotFontStyles.Bold | DotFontStyles.Italic);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_bold_italic_text"
            );
        }

        [Fact]
        public void text_is_embedded_in_all_tags()
        {
            var entity = DotHtmlFontStyle.SetStyle(
                "text",
                DotFontStyles.Bold | DotFontStyles.Italic | DotFontStyles.Underline | DotFontStyles.Overline | DotFontStyles.Subscript | DotFontStyles.Superscript
            );

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_all_tags_text"
            );
        }

        [Fact]
        public void text_items_are_correctly_styled()
        {
            var entity = DotHtmlFontStyle.SetStyles(
                ("Foo ", DotFontStyles.Normal),
                ("Bar ", DotFontStyles.Bold),
                ("Baz ", DotFontStyles.Italic | DotFontStyles.Underline)
            );

            Snapshot.Match(
                ((IDotHtmlEntity) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_multistyling"
            );
        }
    }
}