using System;
using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html
{
    public class DotHtmlCommentTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void encoded_html_comment_is_valid_html()
        {
            var tag = new DotHtmlComment($"My custom comment{Environment.NewLine} < > \" ' & \u00A0");

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_comment"
            );
        }
    }
}