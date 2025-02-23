using GiGraph.Dot.Entities.Html.Rule;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Rules;

public class DotHtmlRulesTest
{
    private readonly DotSyntaxOptions _syntaxOptions = new();
    private readonly DotSyntaxRules _syntaxRules = new();

    [Fact]
    public void encoded_html_vertical_rule_tag_is_valid_html()
    {
        var tag = new DotHtmlVerticalRule();

        Snapshot.Match(
            ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
            "html_vertical_rule"
        );
    }

    [Fact]
    public void encoded_html_horizontal_rule_tag_is_valid_html()
    {
        var tag = new DotHtmlHorizontalRule();

        Snapshot.Match(
            ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
            "html_horizontal_rule"
        );
    }
}