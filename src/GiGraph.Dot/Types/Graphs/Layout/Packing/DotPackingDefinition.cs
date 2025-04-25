using System.Diagnostics.CodeAnalysis;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Graphs.Layout.Packing;

/// <summary>
///     Determines whether packing is enabled (see <see cref="DotPackingEnabled" />) or specifies a margin around each laid out
///     component (see <see cref="DotPackingMargin" />).
/// </summary>
public abstract class DotPackingDefinition : IDotEncodable
{
    string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncodedValue(options, syntaxRules);

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotPackingDefinition?(int? value) => value.HasValue ? new DotPackingMargin(value.Value) : null;

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotPackingDefinition?(bool? value) => value.HasValue ? new DotPackingEnabled(value.Value) : null;

    protected abstract string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules);
}