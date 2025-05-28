using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes;

public abstract class DotAttribute<T>(string key, T value) : DotAttribute(key)
{
    /// <summary>
    ///     Gets the value of the attribute.
    /// </summary>
    public T Value { get; } = value;

    /// <inheritdoc/>
    public override object? GetValue() => Value;

    protected internal override string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => Value?.ToString();
}