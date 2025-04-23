using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Ranks;

/// <summary>
///     Rank separation, in inches.
/// </summary>
public class DotRankSpacing : DotRankSpacingDefinition
{
    /// <summary>
    ///     Creates a new rank separation instance.
    /// </summary>
    /// <param name="distance">
    ///     The minimum vertical distance in inches between the bottom of the nodes in one rank and the tops of nodes in the next.
    /// </param>
    /// <param name="equalSpacing">
    ///     Determines if the centers of all ranks should be spaced equally apart.
    /// </param>
    public DotRankSpacing(double distance, bool equalSpacing = false)
        : this(equalSpacing)
    {
        Distance = distance;
    }

    /// <summary>
    ///     Creates a new rank separation instance.
    /// </summary>
    /// <param name="equalSpacing">
    ///     Determines if the centers of all ranks should be spaced equally apart.
    /// </param>
    public DotRankSpacing(bool equalSpacing)
    {
        EqualSpacing = equalSpacing;
    }

    /// <summary>
    ///     The minimum vertical distance in inches between the bottom of the nodes in one rank and the tops of nodes in the next.
    /// </summary>
    public double? Distance { get; }

    /// <summary>
    ///     Indicates if the centers of all ranks should be spaced equally apart.
    /// </summary>
    public bool EqualSpacing { get; }

    protected override string? GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        const string equally = "equally";
        var result = Distance?.ToString(syntaxRules.Culture);

        if (EqualSpacing)
        {
            return result is not null ? $"{result} {equally}" : equally;
        }

        return result;
    }
}