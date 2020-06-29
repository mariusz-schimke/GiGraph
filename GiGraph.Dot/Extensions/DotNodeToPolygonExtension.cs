using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Nodes;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    /// Provides helper methods for <see cref="DotNode"/>.
    /// </summary>
    public static class DotNodeToPolygonExtension
    {
        /// <summary>
        /// Converts the current node to a polygon shape.
        /// </summary>
        /// <param name="node">The node whose shape to set to polygon.</param>
        /// <param name="sides">The number of sides if <see cref="IDotNodeAttributes.Shape"/> is set to <see cref="DotNodeShape.Polygon"/> (default: 4, minimum: 0).</param>
        /// <param name="regular">If true, forces polygon to be regular, i.e., the vertices of the polygon will lie on a circle
        /// whose center is the center of the node (default: false).</param>
        /// <param name="peripheries">Sets the number of peripheries used in polygonal shapes (<see cref="IDotNodeAttributes.Shape"/>).
        /// The default value is shape dependent, the minimum value is 0.
        /// Note that <see href="http://www.graphviz.org/doc/info/shapes.html#epsf">user-defined shapes</see> are treated
        /// as a form of box shape, so the default peripheries value is 1, and the user-defined shape will be drawn in a bounding rectangle.
        /// Setting peripheries to 0 will turn this off.</param>
        /// <param name="orientation">Angle, in degrees, used to rotate polygon node shapes (<see cref="IDotNodeAttributes.Shape"/> = <see cref="DotNodeShape.Polygon"/>).
        /// For any number of polygon sides, 0 degrees rotation results in a flat base. Default: 0, maximum: 360.</param>
        /// <param name="skew">Skew factor for <see cref="IDotNodeAttributes.Shape"/> set to <see cref="DotNodeShape.Polygon"/> (default: 0, minimum: -100).
        /// Positive values skew top of polygon to right; negative to left.</param>
        /// <param name="distortion">Distortion factor for <see cref="IDotNodeAttributes.Shape"/> set to <see cref="DotNodeShape.Polygon"/> (default: 0, minimum: -100).
        /// Positive values cause top part to be larger than bottom; negative values do the opposite.</param>
        public static void ToPolygon(
            this DotNode node,
            int? sides = null,
            bool? regular = null,
            int? peripheries = null,
            double? orientation = null,
            double? skew = null,
            double? distortion = null)
        {
            node.Attributes.Shape = DotNodeShape.Polygon;

            if (sides.HasValue)
            {
                node.Attributes.Sides = sides;
            }

            if (regular.HasValue)
            {
                node.Attributes.Regular = regular;
            }

            if (peripheries.HasValue)
            {
                node.Attributes.Peripheries = peripheries;
            }

            if (orientation.HasValue)
            {
                node.Attributes.Orientation = orientation;
            }

            if (skew.HasValue)
            {
                node.Attributes.Skew = skew;
            }

            if (distortion.HasValue)
            {
                node.Attributes.Distortion = distortion;
            }
        }
    }
}