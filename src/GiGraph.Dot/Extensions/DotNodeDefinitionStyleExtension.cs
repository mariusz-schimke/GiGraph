using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Extensions
{
    // TODO: problem jest taki, że tych ustawień nie da się zastosować dla globalnych atrybutów (zobaczyć też inne extensions)
    // TODO: testy jednostkowe

    public static class DotNodeDefinitionStyleExtension
    {
        /// <summary>
        ///     Sets a plain-color fill.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="color">
        ///     The color to use.
        /// </param>
        public static void SetPlainColorFill(this DotNodeDefinition node, DotColor color)
        {
            node.Style.FillStyle = DotNodeFillStyle.Normal;
            node.FillColor = color;
        }

        /// <summary>
        ///     Sets a gradient fill.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="color">
        ///     The gradient color definition to use.
        /// </param>
        /// <param name="angle">
        ///     The angle of the fill.
        /// </param>
        /// <param name="radial">
        ///     Determines whether to use a radial-style gradient fill.
        /// </param>
        public static void SetGradientFill(this DotNodeDefinition node, DotGradientColor color, int? angle = null, bool radial = false)
        {
            node.Style.FillStyle = radial ? DotNodeFillStyle.Radial : DotNodeFillStyle.Normal;
            node.FillColor = color;
            node.GradientFillAngle = angle;
        }

        /// <summary>
        ///     Sets a striped fill. Applicable to rectangularly-shaped nodes (see <see cref="DotNodeDefinition.Shape" />).
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetStripedFill(this DotNodeDefinition node, DotMultiColor colors)
        {
            node.Style.FillStyle = DotNodeFillStyle.Striped;
            node.FillColor = colors;
        }

        /// <summary>
        ///     Sets a striped fill. Applicable to rectangularly-shaped nodes.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="shape">
        ///     The shape to set (has to be rectangular).
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetStripedFill(this DotNodeDefinition node, DotNodeShape shape, DotMultiColor colors)
        {
            node.SetStripedFill(colors);
            node.Shape = shape;
        }

        /// <summary>
        ///     Sets a striped fill. Applicable to rectangularly-shaped nodes (see <see cref="DotNodeDefinition.Shape" />).
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetStripedFill(this DotNodeDefinition node, params DotColor[] colors)
        {
            node.SetStripedFill(new DotMultiColor(colors));
        }

        /// <summary>
        ///     Sets a striped fill. Applicable to rectangularly-shaped nodes.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="shape">
        ///     The shape to set (has to be rectangular).
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetStripedFill(this DotNodeDefinition node, DotNodeShape shape, params DotColor[] colors)
        {
            node.SetStripedFill(shape, new DotMultiColor(colors));
        }

        /// <summary>
        ///     Sets a wedged fill. Applicable to elliptically-shaped nodes (see <see cref="DotNodeDefinition.Shape" />).
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive wedges. Proportions for individual wedges may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetWedgedFill(this DotNodeDefinition node, DotMultiColor colors)
        {
            node.Style.FillStyle = DotNodeFillStyle.Wedged;
            node.FillColor = colors;
        }

        /// <summary>
        ///     Sets a wedged fill. Applicable to elliptically-shaped nodes (see <see cref="DotNodeDefinition.Shape" />).
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="shape">
        ///     The shape to set (has to be elliptical).
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive wedges. Proportions for individual wedges may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetWedgedFill(this DotNodeDefinition node, DotNodeShape shape, DotMultiColor colors)
        {
            node.SetWedgedFill(colors);
            node.Shape = shape;
        }

        /// <summary>
        ///     Sets a wedged fill. Applicable to elliptically-shaped nodes (see <see cref="DotNodeDefinition.Shape" />).
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive wedges. Proportions for individual wedges may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetWedgedFill(this DotNodeDefinition node, params DotColor[] colors)
        {
            node.SetWedgedFill(new DotMultiColor(colors));
        }

        /// <summary>
        ///     Sets a wedged fill. Applicable to elliptically-shaped nodes (see <see cref="DotNodeDefinition.Shape" />).
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="shape">
        ///     The shape to set (has to be elliptical).
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive wedges. Proportions for individual wedges may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetWedgedFill(this DotNodeDefinition node, DotNodeShape shape, params DotColor[] colors)
        {
            node.SetWedgedFill(shape, new DotMultiColor(colors));
        }

        /// <summary>
        ///     Converts the current node to a polygon.
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
        public static void SetPolygonalShape(
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
        ///     Converts the current node to a polygon.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="attributes">
        ///     The polygon attributes to set.
        /// </param>
        public static void SetPolygonalShape(this DotNodeDefinition node, DotPolygon attributes)
        {
            node.Shape = DotNodeShape.Polygon;
            node.Geometry.Set(attributes);
        }
    }
}