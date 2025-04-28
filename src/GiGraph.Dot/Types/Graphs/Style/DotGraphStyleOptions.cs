using GiGraph.Dot.Types.Clusters.Style;

namespace GiGraph.Dot.Types.Graphs.Style;

/// <summary>
///     Graph style options.
/// </summary>
public record DotGraphStyleOptions
{
    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public DotGraphStyleOptions()
    {
    }

    /// <summary>
    ///     Creates and initializes a new instance.
    /// </summary>
    /// <param name="fillStyle">
    ///     The fill style for graph and clusters. The only option applicable to the root graph is
    ///     <see cref="DotClusterFillStyle.Radial"/> .
    /// </param>
    public DotGraphStyleOptions(DotClusterFillStyle? fillStyle)
    {
        FillStyle = fillStyle;
    }

    public DotClusterFillStyle? FillStyle { get; init; }
}