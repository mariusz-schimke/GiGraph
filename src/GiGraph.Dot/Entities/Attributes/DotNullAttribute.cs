using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes;

/// <summary>
///     An attribute with no value.
/// </summary>
public class DotNullAttribute : DotAttribute
{
    /// <summary>
    ///     Creates a new instance of the attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    public DotNullAttribute(string key)
        : base(key)
    {
    }

    /// <inheritdoc />
    public override object? GetValue() => null;

    protected internal override string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => null;
}