namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    ///     Represents a color list rendered as dual-color fill when applied to the root graph, node, or cluster. When applied to an
    ///     edge, it is rendered as a single spline with two segments in the specified colors. In both cases the proportions of the
    ///     colors are determined by their weights.
    /// </summary>
    public class DotDualWeightedColor : DotDualColor
    {
        /// <summary>
        ///     Creates a new color list rendered as dual-color fill (refers to the root graph, nodes, and clusters), or as a two-segment
        ///     spline, when applied to an edge. In both cases the proportions of the colors are determined by their weights.
        /// </summary>
        /// <param name="color1">
        ///     The first color to initialize the instance with. Its <see cref="DotWeightedColor.Weight" /> property is the proportion of the
        ///     area to cover with the color (it must be in the range 0 ≤ weight &lt; 1). The weights of the colors must sum to at most 1.
        /// </param>
        /// <param name="color2">
        ///     The second color to initialize the instance with. Its <see cref="DotWeightedColor.Weight" /> property is the proportion of
        ///     the area to cover with the color (it must be in the range 0 ≤ weight &lt; 1). The weights of the colors must sum to at most
        ///     1.
        /// </param>
        public DotDualWeightedColor(DotWeightedColor color1, DotWeightedColor color2)
            : base(color1, color2)
        {
        }

        /// <summary>
        ///     Creates a new color list rendered as dual-color fill (refers to the root graph, nodes, and clusters), or as a two-segment
        ///     spline, when applied to an edge. In both cases the proportions of the colors are determined by their weights.
        /// </summary>
        /// <param name="color1">
        ///     The first color to initialize the instance with. Its <see cref="DotWeightedColor.Weight" /> property is the proportion of the
        ///     area to cover with the color (it must be in the range 0 ≤ weight &lt; 1).
        /// </param>
        /// <param name="color2">
        ///     The second color to initialize the instance with.
        /// </param>
        public DotDualWeightedColor(DotWeightedColor color1, DotColor color2)
            : base(color1, color2)
        {
        }

        /// <summary>
        ///     Creates a new color list rendered as dual-color fill (refers to the root graph, nodes, and clusters), or as a two-segment
        ///     spline, when applied to an edge. In both cases the proportions of the colors are determined by their weights.
        /// </summary>
        /// <param name="color1">
        ///     The first color to initialize the instance with.
        /// </param>
        /// <param name="color2">
        ///     The second color to initialize the instance with. Its <see cref="DotWeightedColor.Weight" /> property is the proportion of
        ///     the area to cover with the color (it must be in the range 0 ≤ weight &lt; 1).
        /// </param>
        public DotDualWeightedColor(DotColor color1, DotWeightedColor color2)
            : base(color1, color2)
        {
        }

        /// <summary>
        ///     Creates a new color list rendered as dual-color fill (refers to the root graph, nodes, and clusters), or as a two-segment
        ///     spline, when applied to an edge. In both cases the proportions of the colors are determined by their weights.
        /// </summary>
        /// <param name="color1">
        ///     The first color to initialize the instance with.
        /// </param>
        /// <param name="weight1">
        ///     The proportion of the area to cover with the first color (it must be in the range 0 ≤ weight &lt; 1).
        /// </param>
        /// <param name="color2">
        ///     The second color to initialize the instance with.
        /// </param>
        /// <param name="weight2">
        ///     The proportion of the area to cover with the second color (it must be in the range 0 ≤ weight &lt; 1).
        /// </param>
        public DotDualWeightedColor(DotColor color1, double weight1, DotColor color2, double weight2)
            : base(new DotWeightedColor(color1, weight1), new DotWeightedColor(color2, weight2))
        {
        }

        /// <summary>
        ///     Creates a new color list rendered as dual-color fill (refers to the root graph, nodes, and clusters), or as a two-segment
        ///     spline, when applied to an edge. In both cases the proportions of the colors are determined by their weights.
        /// </summary>
        /// <param name="color1">
        ///     The first color to initialize the instance with.
        /// </param>
        /// <param name="weight1">
        ///     The proportion of the area to cover with the first color (it must be in the range 0 ≤ weight &lt; 1).
        /// </param>
        /// <param name="color2">
        ///     The second color to initialize the instance with.
        /// </param>
        public DotDualWeightedColor(DotColor color1, double weight1, DotColor color2)
            : base(new DotWeightedColor(color1, weight1), color2)
        {
        }

        /// <summary>
        ///     Creates a new color list rendered as dual-color fill (refers to the root graph, nodes, and clusters), or as a two-segment
        ///     spline, when applied to an edge. In both cases the proportions of the colors are determined by their weights.
        /// </summary>
        /// <param name="color1">
        ///     The first color to initialize the instance with.
        /// </param>
        /// <param name="color2">
        ///     The second color to initialize the instance with.
        /// </param>
        /// <param name="weight2">
        ///     The proportion of the area to cover with the second color (it must be in the range 0 ≤ weight &lt; 1).
        /// </param>
        public DotDualWeightedColor(DotColor color1, DotColor color2, double weight2)
            : base(color1, new DotWeightedColor(color2, weight2))
        {
        }
    }
}