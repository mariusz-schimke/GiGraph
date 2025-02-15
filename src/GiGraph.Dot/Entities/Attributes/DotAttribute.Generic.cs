using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes;

public abstract record DotAttribute<T> : DotAttribute
{
    protected DotAttribute(string key, T? value)
        : base(key)
    {
        Value = value;
    }

    /// <summary>
    ///     Gets the value of the attribute.
    /// </summary>
    public T? Value { get; }

    /// <inheritdoc />
    public override object? GetValue() => Value;

    protected internal override string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => Value?.ToString();
}