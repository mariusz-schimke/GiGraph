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
    ///     <see cref="DotGraphFillStyle.Radial"/> .
    /// </param>
    public DotGraphStyleOptions(DotGraphFillStyle? fillStyle)
    {
        FillStyle = fillStyle;
    }

    public DotGraphFillStyle? FillStyle { get; init; }
}