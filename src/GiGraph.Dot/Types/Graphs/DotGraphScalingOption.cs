using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Graphs;

/// <summary>
///     Scaling mode of the graph drawing.
/// </summary>
/// <param name="Option">
///     The scaling option.
/// </param>
public record DotGraphScalingOption(DotGraphScaling Option) : DotGraphScalingDefinition
{
    protected override string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => DotAttributeValue.Get(Option);
}