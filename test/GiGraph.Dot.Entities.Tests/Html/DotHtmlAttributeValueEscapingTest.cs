using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.EscapeString;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html;

public class DotHtmlAttributeValueEscapingTest
{
    public const string SpecialChars = "\" \\ \r\n \r \n { } | < > \" ' & \u00A0";

    private readonly DotSyntaxOptions _syntaxOptions = new();
    private readonly DotSyntaxRules _syntaxRules = new();

    [Fact]
    public void string_value_is_escaped()
    {
        var value = $"String value {SpecialChars}";
        var element = new DotHtmlVoidElement("element");
        element.Attributes.Set("attribute", value);

        Snapshot.Match(
            ((IDotHtmlEncodable) element).ToHtml(_syntaxOptions, _syntaxRules),
            "html_attribute_string_value"
        );
    }

    [Fact]
    public void escape_string_value_is_escaped()
    {
        var value = (DotEscapeString) $"Escape string value {SpecialChars}";
        var element = new DotHtmlVoidElement("element");
        element.Attributes.Set("attribute", value);

        Snapshot.Match(
            ((IDotHtmlEncodable) element).ToHtml(_syntaxOptions, _syntaxRules),
            "html_attribute_escape_string_value"
        );
    }

    [Fact]
    public void escape_string_value_stays_as_is()
    {
        var value = $"Unchanged value {SpecialChars}";
        var element = new DotHtmlVoidElement("element");
        element.Attributes.SetRaw("attribute", value);

        Snapshot.Match(
            ((IDotHtmlEncodable) element).ToHtml(_syntaxOptions, _syntaxRules),
            "html_attribute_raw_string_value"
        );
    }
}