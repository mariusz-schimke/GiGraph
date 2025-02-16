using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Attributes;

/// <summary>
///     A DOT-encodable value attribute.
/// </summary>
/// <typeparam name="TComplex">
///     A complex type that implements the <see cref="IDotEncodable" /> interface.
/// </typeparam>
public class DotComplexTypeAttribute<TComplex> : DotAttribute<TComplex>
    where TComplex : IDotEncodable
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
    public DotComplexTypeAttribute(string key, TComplex value)
        : base(key, value)
    {
    }

    protected internal override string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) =>
        Value.GetDotEncodedValue(options, syntaxRules);
}