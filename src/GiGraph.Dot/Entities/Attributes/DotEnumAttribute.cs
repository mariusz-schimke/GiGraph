using System;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes;

/// <summary>
///     An enumeration attribute.
/// </summary>
/// <typeparam name="TEnum">
///     An enumeration type whose values are annotated with the <see cref="DotAttributeValueAttribute" /> attributes.
/// </typeparam>
public record DotEnumAttribute<TEnum> : DotAttribute<TEnum>
    where TEnum : Enum
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
    public DotEnumAttribute(string key, TEnum value)
        : base(key, value)
    {
    }

    protected internal override string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) =>
        DotAttributeValue.TryGetAsFlags(Value, out var result)
            ? result
            : DotAttributeValue.Get(Value);
}