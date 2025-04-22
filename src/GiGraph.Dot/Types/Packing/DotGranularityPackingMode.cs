using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Packing;

/// <summary>
///     A graph packing mode based on a granularity option. Indicates that components should be packed together tightly, using the
///     specified granularity.
/// </summary>
/// <param name="granularity">
///     The granularity option.
/// </param>
public class DotGranularityPackingMode(DotPackingGranularity granularity) : DotPackingModeDefinition
{
    /// <summary>
    ///     The granularity option.
    /// </summary>
    public DotPackingGranularity Granularity { get; } = granularity;

    protected override string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => DotAttributeValue.Get(Granularity);
}