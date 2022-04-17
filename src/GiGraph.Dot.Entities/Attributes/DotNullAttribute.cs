using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes;

/// <summary>
///     An attribute with no value.
/// </summary>
public record DotNullAttribute : DotAttribute
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
    public override object GetValue()
    {
        return null;
    }

    protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        return null;
    }
}