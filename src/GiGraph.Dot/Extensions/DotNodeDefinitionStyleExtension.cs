using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Extensions
{
    public static class DotNodeDefinitionStyleExtension
    {
        /// <summary>
        ///     Sets a wedged fill, assuming that the node has an elliptical shape (see <see cref="IDotNodeAttributes.Shape" />).
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive wedges. Proportions for individual wedges may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetWedged(this DotNodeDefinition node, DotMultiColor colors)
        {
            node.Style.FillStyle = DotNodeFillStyle.Wedged;
            node.FillColor = colors;
        }

        /// <summary>
        ///     Sets a wedged fill, assuming that the node has an elliptical shape (see <see cref="IDotNodeAttributes.Shape" />).
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive wedges. Proportions for individual wedges may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetWedged(this DotNodeDefinition node, params DotColor[] colors)
        {
            node.SetWedged(new DotMultiColor(colors));
        }

        /// <summary>
        ///     Converts the current node to a polygon shape.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="sides">
        ///     The number of sides if <see cref="IDotNodeAttributes.Shape" /> is set to <see cref="DotNodeShape.Polygon" /> (default: 4,
        ///     minimum: 0).
        /// </param>
        /// <param name="regular">
        ///     If true, forces polygon to be regular, i.e., the vertices of the polygon will lie on a circle whose center is the center of
        ///     the node (default: false).
        /// </param>
        /// <param name="peripheries">
        ///     Sets the number of peripheries used in polygonal shapes (<see cref="IDotNodeAttributes.Shape" />). The default value is shape
        ///     dependent, the minimum value is 0. Note that
        ///     <see href="http://www.graphviz.org/doc/info/shapes.html#epsf">
        ///         user-defined shapes
        ///     </see>
        ///     are treated as a form of box shape, so the default peripheries value is 1, and the user-defined shape will be drawn in a
        ///     bounding rectangle. Setting peripheries to 0 will turn this off.
        /// </param>
        /// <param name="rotation">
        ///     Angle, in degrees, used to rotate polygon node shapes (<see cref="IDotNodeAttributes.Shape" /> =
        ///     <see cref="DotNodeShape.Polygon" />). For any number of polygon sides, 0 degrees rotation results in a flat base. Default: 0,
        ///     maximum: 360.
        /// </param>
        /// <param name="skew">
        ///     Skew factor for <see cref="IDotNodeAttributes.Shape" /> set to <see cref="DotNodeShape.Polygon" /> (default: 0, minimum:
        ///     -100). Positive values skew top of polygon to right; negative to left.
        /// </param>
        /// <param name="distortion">
        ///     Distortion factor for <see cref="IDotNodeAttributes.Shape" /> set to <see cref="DotNodeShape.Polygon" /> (default: 0,
        ///     minimum: -100). Positive values cause top part to be larger than bottom; negative values do the opposite.
        /// </param>
        public static void SetPolygonal(
            this DotNodeDefinition node,
            int? sides = null,
            bool? regular = null,
            int? peripheries = null,
            double? rotation = null,
            double? skew = null,
            double? distortion = null)
        {
            node.Shape = DotNodeShape.Polygon;
            node.Geometry.Set(sides, regular, peripheries, rotation, skew, distortion);
        }

        /// <summary>
        ///     Converts the current node to a polygon shape.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="attributes">
        ///     The polygon attributes to set.
        /// </param>
        public static void SetPolygonal(this DotNodeDefinition node, DotPolygon attributes)
        {
            node.Shape = DotNodeShape.Polygon;
            node.Geometry.Set(attributes);
        }
    }
}