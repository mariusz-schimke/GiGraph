using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Html.Attributes;

/// <summary>
///     A string attribute. The value is rendered as is in the output DOT script, so the attribute can be used for any type of value,
///     not only for strings. For use in the context of HTML elements
/// </summary>
public record DotHtmlStringAttribute : DotStringAttribute
{
    /// <summary>
    ///     Creates a new instance of the attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public DotHtmlStringAttribute(string key, DotEscapeString value)
        : base(key, value)
    {
    }

    protected internal override string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) =>
        syntaxRules.Attributes.Html.AttributeValueEscaper.Escape(Value);
}