using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Ranks;

/// <summary>
///     Rank separation, in inches.
/// </summary>
public record DotRankSeparation : DotRankSeparationDefinition
{
    /// <summary>
    ///     Creates a new rank separation instance.
    /// </summary>
    /// <param name="value">
    ///     The minimum vertical distance in inches between the bottom of the nodes in one rank and the tops of nodes in the next.
    /// </param>
    /// <param name="equal">
    ///     Determines if the centers of all ranks should be spaced equally apart.
    /// </param>
    public DotRankSeparation(double value, bool equal = false)
        : this(equal)
    {
        Value = value;
    }

    /// <summary>
    ///     Creates a new rank separation instance.
    /// </summary>
    /// <param name="equal">
    ///     Determines if the centers of all ranks should be spaced equally apart.
    /// </param>
    public DotRankSeparation(bool equal)
    {
        Equal = equal;
    }

    /// <summary>
    ///     The minimum vertical distance in inches between the bottom of the nodes in one rank and the tops of nodes in the next.
    /// </summary>
    public double? Value { get; init; }

    /// <summary>
    ///     Indicates if the centers of all ranks should be spaced equally apart.
    /// </summary>
    public bool Equal { get; init; }

    protected override string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        const string equally = "equally";
        var result = Value?.ToString(syntaxRules.Culture);

        if (Equal)
        {
            return result is not null ? $"{result} {equally}" : equally;
        }

        return result;
    }
}