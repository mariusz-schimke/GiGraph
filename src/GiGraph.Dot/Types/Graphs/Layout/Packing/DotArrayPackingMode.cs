using System.Text;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Packing;

/// <summary>
///     Array packing mode parameters. Indicates that the components should be packed at the graph level into an array of graphs. By
///     default, the components are in row-major order, with the number of columns roughly the square root of the number of
///     components.
/// </summary>
/// <remarks>
///     For example, the mode <see cref="DotArrayPackingOptions.ColumnMajorOrder"/> with 4 as the rankCount indicates array packing,
///     with 4 rows, starting in the upper left and going down the first column, then down the second column, etc., until all
///     components are used.
/// </remarks>
public class DotArrayPackingMode : DotPackingModeDefinition
{
    /// <summary>
    ///     Creates a new array packing mode instance.
    /// </summary>
    /// <param name="rankCount">
    ///     Specifies the number of columns for row-major component ordering or the number of rows for column-major component ordering.
    /// </param>
    public DotArrayPackingMode(int rankCount)
    {
        RankCount = rankCount;
    }

    /// <summary>
    ///     Creates a new array packing mode instance.
    /// </summary>
    /// <param name="options">
    ///     The options to initialize the instance with.
    /// </param>
    /// <param name="rankCount">
    ///     Specifies the number of columns for row-major component ordering or the number of rows for column-major component ordering.
    /// </param>
    public DotArrayPackingMode(DotArrayPackingOptions? options = null, int? rankCount = null)
    {
        Options = options;
        RankCount = rankCount;
    }

    /// <summary>
    ///     The granularity option.
    /// </summary>
    public DotArrayPackingOptions? Options { get; }

    /// <summary>
    ///     The number of columns for row-major component ordering or the number of rows for column-major component ordering (see
    ///     <see cref="DotArrayPackingOptions.ColumnMajorOrder"/>).
    /// </summary>
    public int? RankCount { get; }

    protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        var result = new StringBuilder("array");

        if (Options.HasValue)
        {
            result.Append('_');
            result.Append(DotAttributeValue.GetAsFlags(Options.Value));
        }

        if (RankCount.HasValue)
        {
            result.Append(RankCount.Value);
        }

        return result.ToString();
    }
}