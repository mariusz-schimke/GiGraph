using GiGraph.Dot.Entities.Html.Image;
using GiGraph.Dot.Entities.Html.LineBreak;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Images;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html
{
    public class DotHtmlLineBreakTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void encoded_html_line_break_tag_is_valid_html()
        {
            var tag = new DotHtmlLineBreak();

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_line_break"
            );
        }

        [Fact]
        public void encoded_html_aligned_line_break_tag_is_valid_html()
        {
            var tag = new DotHtmlLineBreak(DotHorizontalAlignment.Right);

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_line_break_right-aligned"
            );
        }
    }
}