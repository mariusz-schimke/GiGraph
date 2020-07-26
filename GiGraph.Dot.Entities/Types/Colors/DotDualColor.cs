using System.Drawing;

namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    ///     Represents a color list rendered as dual-color fill when applied to the root graph, node, or cluster, assuming that a weight
    ///     is specified for either of the colors. When applied to an edge, it will be rendered as two parallel splines in the specified
    ///     colors (if no weights are present), or as a single spline with two segments in the specified colors if a weight is specified
    ///     for either of the colors.
    /// </summary>
    public class DotDualColor : DotMultiColor
    {
        /// <summary>
        ///     Creates a new color list rendered as dual-color fill (refers to the root graph, nodes, and clusters), or as a two-segment
        ///     spline, when applied to an edge. Note that if no weights are specified, it is rendered as gradient fill (refers to the root
        ///     graph, nodes, and clusters), or as two parallel splines when applied to an edge.
        /// </summary>
        /// <param name="color1">
        ///     The first color to initialize the instance with.
        /// </param>
        /// <param name="color2">
        ///     The second color to initialize the instance with.
        /// </param>
        /// <param name="weight1">
        ///     The optional weight of the first color, that is the proportion of the area to cover with the color. If both weight parameters
        ///     are specified, they must sum to at most 1. If only one of them is specified, it must be in the range 0 ≤
        ///     <paramref name="weight1" /> &lt; 1.
        /// </param>
        /// <param name="weight2">
        ///     The optional weight of the second color, that is the proportion of the area to cover with the color. If both weight
        ///     parameters are specified, they must sum to at most 1. If only one of them is specified, it must be in the range 0 ≤
        ///     <paramref name="weight2" /> &lt; 1.
        /// </param>
        public DotDualColor(Color color1, Color color2, double? weight1 = null, double? weight2 = null)
            : base(Weighted(color1, weight1), Weighted(color2, weight2))
        {
        }

        protected static DotColor Weighted(Color color, double? weight)
        {
            return weight.HasValue
                ? new DotWeightedColor(color, weight.Value)
                : new DotColor(color);
        }
    }
}