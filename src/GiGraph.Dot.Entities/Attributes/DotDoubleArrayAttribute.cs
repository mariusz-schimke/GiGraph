using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Encoders;

namespace GiGraph.Dot.Entities.Attributes;

/// <summary>
///     A double array attribute.
/// </summary>
public record DotDoubleArrayAttribute : DotAttribute<double[]>
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
    public DotDoubleArrayAttribute(string key, double[] value)
        : base(key, value)
    {
    }

    protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        return Value is not null ? DotDoubleListEncoder.Encode(Value, syntaxRules) : null;
    }
}