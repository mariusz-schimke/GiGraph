using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Encoders;

namespace GiGraph.Dot.Types.Ranks;

/// <summary>
///     Radial separation of concentric circles in twopi.
/// </summary>
public class DotRadialRankSeparation : DotRankSeparationDefinition
{
    /// <summary>
    ///     Creates a new rank separation instance.
    /// </summary>
    /// <param name="values">
    ///     The first double specifies the radius of the inner circle; the second double specifies the increase in radius from the first
    ///     circle to the second; etc. If there are more circles than numbers, the last number is used as the increment for the
    ///     remainder.
    /// </param>
    public DotRadialRankSeparation(params double[] values)
    {
        Values = values ?? throw new ArgumentNullException(nameof(values), "Value collection must not be null.");
    }

    /// <summary>
    ///     Creates a new rank separation instance.
    /// </summary>
    /// <param name="value">
    ///     The first double specifies the radius of the inner circle; the second double specifies the increase in radius from the first
    ///     circle to the second; etc. If there are more circles than numbers, the last number is used as the increment for the
    ///     remainder.
    /// </param>
    public DotRadialRankSeparation(IEnumerable<double> value)
        : this(value.ToArray())
    {
    }

    /// <summary>
    ///     The first double specifies the radius of the inner circle; the second double specifies the increase in radius from the first
    ///     circle to the second; etc. If there are more circles than numbers, the last number is used as the increment for the
    ///     remainder.
    /// </summary>
    public double[] Values { get; }

    protected override string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => DotDoubleListEncoder.Encode(Values, syntaxRules);
}