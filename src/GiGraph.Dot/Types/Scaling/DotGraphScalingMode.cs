using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Scaling;

/// <summary>
///     Scaling mode of the graph drawing.
/// </summary>
/// <param name="mode">
///     The scaling mode to use.
/// </param>
public class DotGraphScalingMode(DotGraphScaling mode) : DotGraphScalingDefinition
{
    /// <summary>
    ///     The scaling option.
    /// </summary>
    public DotGraphScaling Mode { get; } = mode;

    protected override string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => DotAttributeValue.Get(Mode);
}