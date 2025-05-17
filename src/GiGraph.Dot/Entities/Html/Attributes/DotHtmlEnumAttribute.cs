using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Metadata.Html;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Html.Attributes;

/// <summary>
///     An enumeration attribute for use in the context of HTML elements.
/// </summary>
/// <typeparam name="TEnum">
///     An enumeration type whose values are annotated with the <see cref="DotAttributeValueAttribute"/> attributes.
/// </typeparam>
public class DotHtmlEnumAttribute<TEnum> : DotEnumAttribute<TEnum>
    where TEnum : struct, Enum
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
    public DotHtmlEnumAttribute(string key, TEnum value)
        : base(key, value)
    {
    }

    protected internal override string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) =>
        DotHtmlAttributeValue.TryGetAsFlags(Value, out var result)
            ? result
            : DotHtmlAttributeValue.Get(Value);
}