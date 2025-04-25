using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Scaling;

/// <summary>
///     Scaling mode of the graph drawing.
/// </summary>
/// <param name="option">
///     The scaling option.
/// </param>
public class DotGraphScalingOption(DotGraphScaling option) : DotGraphScalingDefinition
{
    /// <summary>
    ///     The scaling option.
    /// </summary>
    public DotGraphScaling Option { get; } = option;

    protected override string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => DotAttributeValue.Get(Option);
}