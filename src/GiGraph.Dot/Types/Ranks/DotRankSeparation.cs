using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Ranks;

/// <summary>
///     Rank separation, in inches.
/// </summary>
public class DotRankSeparation : DotRankSeparationDefinition
{
    /// <summary>
    ///     Creates a new rank separation instance.
    /// </summary>
    /// <param name="minNodeDistance">
    ///     The minimum vertical distance in inches between the bottom of the nodes in one rank and the tops of nodes in the next.
    /// </param>
    /// <param name="equalRankSpacing">
    ///     Determines if the centers of all ranks should be spaced equally apart.
    /// </param>
    public DotRankSeparation(double? minNodeDistance, bool equalRankSpacing = false)
    {
        MinNodeDistance = minNodeDistance;
        EqualRankSpacing = equalRankSpacing;
    }

    /// <summary>
    ///     The minimum vertical distance in inches between the bottom of the nodes in one rank and the tops of nodes in the next.
    /// </summary>
    public double? MinNodeDistance { get; }

    /// <summary>
    ///     Indicates if the centers of all ranks should be spaced equally apart.
    /// </summary>
    public bool EqualRankSpacing { get; }

    protected override string? GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        const string equally = "equally";
        var result = MinNodeDistance?.ToString(syntaxRules.Culture);

        if (EqualRankSpacing)
        {
            return result is not null ? $"{result} {equally}" : equally;
        }

        return result;
    }
}