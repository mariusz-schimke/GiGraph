using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Encoders;

namespace GiGraph.Dot.Types.Graphs.Layout.Spacing;

/// <summary>
///     Radial separation of concentric circles in twopi.
/// </summary>
public class DotRadialRankSeparation : DotRankSeparationDefinition
{
    /// <summary>
    ///     Creates a new rank separation instance.
    /// </summary>
    /// <param name="radii">
    ///     The first double specifies the radius of the inner circle; the second double specifies the increase in radius from the first
    ///     circle to the second; etc. If there are more circles than numbers, the last number is used as the increment for the
    ///     remainder.
    /// </param>
    public DotRadialRankSeparation(params double[] radii)
    {
        Radii = radii ?? throw new ArgumentNullException(nameof(radii), "Radii collection must not be null.");
    }

    /// <summary>
    ///     Creates a new rank separation instance.
    /// </summary>
    /// <param name="radii">
    ///     The first double specifies the radius of the inner circle; the second double specifies the increase in radius from the first
    ///     circle to the second; etc. If there are more circles than numbers, the last number is used as the increment for the
    ///     remainder.
    /// </param>
    public DotRadialRankSeparation(IEnumerable<double> radii)
        : this(radii.ToArray())
    {
    }

    /// <summary>
    ///     The first double specifies the radius of the inner circle; the second double specifies the increase in radius from the first
    ///     circle to the second; etc. If there are more circles than numbers, the last number is used as the increment for the
    ///     remainder.
    /// </summary>
    public double[] Radii { get; }

    protected override string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => DotDoubleListEncoder.Encode(Radii, syntaxRules);
}