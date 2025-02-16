namespace GiGraph.Dot.Types.Colors;

/// <summary>
///     <para>
///         Represents a color definition visualized as a gradient fill when applied to the root graph, node, or cluster, if no
///         weighted colors are used (<see cref="DotColor" /> only).
///     </para>
///     <para>
///         If at least one weighted color is specified (see <see cref="DotWeightedColor" />), a degenerate linear gradient fill is
///         done. This essentially does a fill using two colors, with the <see cref="DotWeightedColor.Weight" /> specifying how much
///         of region is filled with each color.
///     </para>
/// </summary>
public class DotGradientColor : DotMulticolor
{
    /// <summary>
    ///     <para>
    ///         Creates a new color definition visualized as a gradient fill when applied to the root graph, node, or cluster, if no
    ///         weighted colors are used (<see cref="DotColor" /> only).
    ///     </para>
    ///     <para>
    ///         If at least one weighted color is specified (see <see cref="DotWeightedColor" />), a degenerate linear gradient fill is
    ///         done. This essentially does a fill using two colors, with the <see cref="DotWeightedColor.Weight" /> specifying how much
    ///         of region is filled with each color.
    ///     </para>
    /// </summary>
    /// <param name="startColor">
    ///     The start color of the gradient fill.
    /// </param>
    /// <param name="endColor">
    ///     The end color of the gradient fill.
    /// </param>
    public DotGradientColor(DotColor startColor, DotColor endColor)
        : base(startColor, endColor)
    {
    }

    /// <summary>
    ///     The start color of the gradient fill.
    /// </summary>
    public DotColor StartColor
    {
        get => Colors[0];
        init => Colors[0] = value;
    }

    /// <summary>
    ///     The end color of the gradient fill.
    /// </summary>
    public DotColor EndColor
    {
        get => Colors[1];
        init => Colors[1] = value;
    }
}