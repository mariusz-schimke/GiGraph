using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Entities.Html.Font.Styles;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.FontStyles
{
    public partial class DotHtmlFontStyleTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void encoded_html_italic_tag_is_valid_html()
        {
            var tag = new DotHtmlItalic("italic text");

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_italic_text"
            );
        }

        [Fact]
        public void encoded_html_bold_tag_is_valid_html()
        {
            var tag = new DotHtmlBold("bold text");

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_bold_text"
            );
        }

        [Fact]
        public void encoded_html_underline_tag_is_valid_html()
        {
            var tag = new DotHtmlUnderline("underlined text");

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_underlined_text"
            );
        }

        [Fact]
        public void encoded_html_strikethrough_tag_is_valid_html()
        {
            var tag = new DotHtmlStrikethrough("strikethrough text");

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_strikethrough_text"
            );
        }

        [Fact]
        public void encoded_html_superscript_tag_is_valid_html()
        {
            var tag = new DotHtmlSuperscript("superscript text");

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_superscript_text"
            );
        }

        [Fact]
        public void encoded_html_subscript_tag_is_valid_html()
        {
            var tag = new DotHtmlSubscript("subscript text");

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_subscript_text"
            );
        }

        [Fact]
        public void encoded_html_overline_tag_is_valid_html()
        {
            var tag = new DotHtmlOverline("overline text");

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_overline_text"
            );
        }
    }
}