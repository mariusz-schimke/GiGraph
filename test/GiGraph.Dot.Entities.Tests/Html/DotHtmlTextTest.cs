using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.Alignment;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html;

public class DotHtmlTextTest
{
    private readonly DotSyntaxOptions _syntaxOptions = new();
    private readonly DotSyntaxRules _syntaxRules = new();

    [Fact]
    public void multiline_text_is_split_with_br_elements()
    {
        var text = $"Line 1{Environment.NewLine}Line 2";
        var entity = new DotHtmlText(text);

        Snapshot.Match(
            ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
            "html_multiline_text"
        );

        // this should generate the same result
        var element = new DotHtmlText(text);
        Snapshot.Match(
            ((IDotHtmlEncodable) element).ToHtml(_syntaxOptions, _syntaxRules),
            "html_multiline_text"
        );
    }

    [Fact]
    public void text_is_escaped()
    {
        var element = new DotHtmlText("My custom text < > \" ' &  ");

        Snapshot.Match(
            ((IDotHtmlEncodable) element).ToHtml(_syntaxOptions, _syntaxRules),
            "html_escaped_text"
        );
    }

    [Fact]
    public void multiline_text_is_split_with_br_elements_with_alignment()
    {
        var text = $"Line 1{Environment.NewLine}Line 2";
        var entity = new DotHtmlText(text, DotHorizontalAlignment.Right);

        Snapshot.Match(
            ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
            "html_multiline_right-aligned_text"
        );
    }

    [Fact]
    public void single_line_text_is_not_split()
    {
        const string text = "Line 1";
        var entity = new DotHtmlText(text);

        Snapshot.Match(
            ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
            "html_single-line_text"
        );

        // this should generate the same result
        var element = new DotHtmlText(text);
        Snapshot.Match(
            ((IDotHtmlEncodable) element).ToHtml(_syntaxOptions, _syntaxRules),
            "html_single-line_text"
        );
    }
}