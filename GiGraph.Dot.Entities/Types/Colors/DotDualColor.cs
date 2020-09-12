using System.Drawing;

namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    ///     Represents a color list that is rendered as two parallel splines with the specified colors when applied to an edge.
    /// </summary>
    public class DotDualColor : DotMultiColor
    {
        /// <summary>
        ///     Creates a new color definition rendered as two parallel splines with the specified colors when applied to an edge.
        /// </summary>
        /// <param name="color1">
        ///     The color of the first spline.
        /// </param>
        /// <param name="color2">
        ///     The color of the second spline.
        /// </param>
        public DotDualColor(Color color1, Color color2)
            : base(color1, color2)
        {
        }

        /// <summary>
        ///     Creates a new color definition rendered as two parallel splines with the specified colors when applied to an edge.
        /// </summary>
        /// <param name="color1">
        ///     The color of the first spline.
        /// </param>
        /// <param name="color2">
        ///     The color of the second spline.
        /// </param>
        public DotDualColor(DotColor color1, DotColor color2)
            : base(color1, color2)
        {
        }
    }
}