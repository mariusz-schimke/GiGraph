using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Graphs;

/// <summary>
///     The aspect ratio of the graph. If ratio = x where x is a floating point number, then the drawing is scaled up in one
///     dimension to achieve the requested ratio expressed as drawing height/width. For example, ratio = 2.0 makes the drawing twice
///     as high as it is wide.
/// </summary>
/// <param name="ratio">
///     The aspect ratio.
/// </param>
public class DotGraphScalingAspectRatio(double ratio) : DotGraphScalingDefinition
{
    /// <summary>
    ///     The aspect ratio.
    /// </summary>
    public double Ratio { get; } = ratio;

    protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => Ratio.ToString(syntaxRules.Culture);
}