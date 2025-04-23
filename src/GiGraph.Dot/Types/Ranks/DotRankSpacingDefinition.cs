using System.Diagnostics.CodeAnalysis;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Ranks;

/// <summary>
///     Rank separation (see <see cref="DotRankSpacing" /> and <see cref="DotRadialSpacing" />).
/// </summary>
public abstract class DotRankSpacingDefinition : IDotEncodable
{
    string? IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncoded(options, syntaxRules);

    protected abstract string? GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotRankSpacingDefinition?(double? value) => value.HasValue ? new DotRankSpacing(value.Value) : null;

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotRankSpacingDefinition?(double[]? value) => value is not null ? new DotRadialSpacing(value) : null;
}