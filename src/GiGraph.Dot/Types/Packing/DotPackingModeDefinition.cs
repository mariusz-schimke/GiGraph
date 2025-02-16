using System.Diagnostics.CodeAnalysis;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Packing;

/// <summary>
///     Packing mode definition with two supported options: packing with specified granularity (see
///     <see cref="DotGranularPackingMode" />) or array packing (see <see cref="DotArrayPackingMode" />).
/// </summary>
public abstract class DotPackingModeDefinition : IDotEncodable
{
    string? IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncodedValue(options, syntaxRules);

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotPackingModeDefinition?(DotPackingGranularity? value) => value.HasValue ? new DotGranularPackingMode(value.Value) : null;

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotPackingModeDefinition?(DotArrayPackingOptions? value) => value.HasValue ? new DotArrayPackingMode(value.Value) : null;

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotPackingModeDefinition?(int? value) => value.HasValue ? new DotArrayPackingMode(value.Value) : null;

    protected abstract string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules);
}