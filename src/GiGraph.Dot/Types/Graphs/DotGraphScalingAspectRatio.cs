using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Graphs;

/// <summary>
///     The aspect ratio of the graph. If ratio = x where x is a floating point number, then the drawing is scaled up in one
///     dimension to achieve the requested ratio expressed as drawing height/width. For example, ratio = 2.0 makes the drawing twice
///     as high as it is wide.
/// </summary>
/// <param name="Ratio">
///     The aspect ratio.
/// </param>
public record DotGraphScalingAspectRatio(double Ratio) : DotGraphScalingDefinition
{
    protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => Ratio.ToString(syntaxRules.Culture);
}