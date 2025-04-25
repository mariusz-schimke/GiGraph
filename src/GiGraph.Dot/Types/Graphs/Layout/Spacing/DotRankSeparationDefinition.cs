using System.Diagnostics.CodeAnalysis;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Graphs.Layout.Spacing;

/// <summary>
///     Rank separation (see <see cref="DotRankSeparation" /> and <see cref="DotRadialRankSeparation" />).
/// </summary>
public abstract class DotRankSeparationDefinition : IDotEncodable
{
    string? IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncoded(options, syntaxRules);

    protected abstract string? GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotRankSeparationDefinition?(double? value) => value.HasValue ? new DotRankSeparation(value.Value) : null;

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotRankSeparationDefinition?(double[]? value) => value is not null ? new DotRadialRankSeparation(value) : null;
}