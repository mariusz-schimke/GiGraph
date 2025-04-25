using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Scaling;

/// <summary>
///     The aspect ratio of the graph. If ratio = x where x is a floating point number, then the drawing is scaled up in one
///     dimension to achieve the requested ratio expressed as drawing height/width. For example, ratio = 2.0 makes the drawing twice
///     as high as it is wide.
/// </summary>
/// <param name="aspectRatio">
///     The aspect ratio to use.
/// </param>
public class DotGraphScalingAspectRatio(double aspectRatio) : DotGraphScalingDefinition
{
    /// <summary>
    ///     The aspect ratio.
    /// </summary>
    public double AspectRatio { get; } = aspectRatio;

    protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => AspectRatio.ToString(syntaxRules.Culture);
}