using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Packing;

/// <summary>
///     A graph packing mode based on a granularity option.
/// </summary>
/// <param name="Granularity">
///     The granularity option.
/// </param>
public record DotGranularPackingMode(DotPackingGranularity Granularity) : DotPackingModeDefinition
{
    protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => DotAttributeValue.Get(Granularity);
}