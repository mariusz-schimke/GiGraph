namespace GiGraph.Dot.Entities.Types.Colors
{
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
    public class DotGradientColor : DotMultiColor
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
    }
}