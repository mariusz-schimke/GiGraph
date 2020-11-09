using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Geometry;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public partial class DotNodeAttributes
    {
        /// <summary>
        ///     Makes the node invisible.
        /// </summary>
        public virtual DotNodeAttributes SetInvisible()
        {
            Style.Invisible = true;
            return this;
        }

        /// <summary>
        ///     Sets a fill color.
        /// </summary>
        /// <param name="color">
        ///     The color to use.
        /// </param>
        public virtual DotNodeAttributes SetFilled(DotColor color)
        {
            Style.FillStyle = DotNodeFillStyle.Normal;
            FillColor = color;
            return this;
        }

        /// <summary>
        ///     Sets a gradient fill.
        /// </summary>
        /// <param name="color">
        ///     The gradient color definition to use.
        /// </param>
        /// <param name="angle">
        ///     The angle of the fill.
        /// </param>
        /// <param name="radial">
        ///     Determines whether to use a radial-style gradient fill.
        /// </param>
        public virtual DotNodeAttributes SetFilled(DotGradientColor color, int? angle = null, bool radial = false)
        {
            Style.FillStyle = radial ? DotNodeFillStyle.Radial : DotNodeFillStyle.Normal;
            FillColor = color;
            GradientAngle = angle;

            return this;
        }

        /// <summary>
        ///     Sets a wedged fill, assuming that the node has an elliptical shape (see <see cref="DotNodeAttributes.Shape" />).
        /// </summary>
        /// <param name="colors">
        ///     The colors to use for consecutive wedges. Proportions for individual wedges may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public virtual DotNodeAttributes SetWedged(DotMultiColor colors)
        {
            Style.FillStyle = DotNodeFillStyle.Wedged;
            FillColor = colors;
            return this;
        }

        /// <summary>
        ///     Sets a striped fill, assuming that the node has a rectangular shape (see <see cref="DotNodeAttributes.Shape" />).
        /// </summary>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public virtual DotNodeAttributes SetStriped(DotMultiColor colors)
        {
            Style.FillStyle = DotNodeFillStyle.Striped;
            FillColor = colors;
            return this;
        }

        /// <summary>
        ///     Converts the current node to a polygon shape.
        /// </summary>
        /// <param name="sides">
        ///     The number of sides if <see cref="DotNodeAttributes.Shape" /> is set to <see cref="DotNodeShape.Polygon" /> (default: 4,
        ///     minimum: 0).
        /// </param>
        /// <param name="regular">
        ///     If true, forces polygon to be regular, i.e., the vertices of the polygon will lie on a circle whose center is the center of
        ///     the node (default: false).
        /// </param>
        /// <param name="peripheries">
        ///     Sets the number of peripheries used in polygonal shapes (<see cref="DotNodeAttributes.Shape" />). The default value is shape
        ///     dependent, the minimum value is 0. Note that
        ///     <see href="http://www.graphviz.org/doc/info/shapes.html#epsf">
        ///         user-defined shapes
        ///     </see>
        ///     are treated as a form of box shape, so the default peripheries value is 1, and the user-defined shape will be drawn in a
        ///     bounding rectangle. Setting peripheries to 0 will turn this off.
        /// </param>
        /// <param name="rotation">
        ///     Angle, in degrees, used to rotate polygon node shapes (<see cref="DotNodeAttributes.Shape" /> =
        ///     <see cref="DotNodeShape.Polygon" />). For any number of polygon sides, 0 degrees rotation results in a flat base. Default: 0,
        ///     maximum: 360.
        /// </param>
        /// <param name="skew">
        ///     Skew factor for <see cref="DotNodeAttributes.Shape" /> set to <see cref="DotNodeShape.Polygon" /> (default: 0, minimum:
        ///     -100). Positive values skew top of polygon to right; negative to left.
        /// </param>
        /// <param name="distortion">
        ///     Distortion factor for <see cref="DotNodeAttributes.Shape" /> set to <see cref="DotNodeShape.Polygon" /> (default: 0, minimum:
        ///     -100). Positive values cause top part to be larger than bottom; negative values do the opposite.
        /// </param>
        public virtual DotNodeAttributes SetPolygonal(
            int? sides = null,
            bool? regular = null,
            int? peripheries = null,
            double? rotation = null,
            double? skew = null,
            double? distortion = null)
        {
            Shape = DotNodeShape.Polygon;
            Geometry.Set(sides, regular, peripheries, rotation, skew, distortion);
            return this;
        }

        /// <summary>
        ///     Converts the current node to a polygon shape.
        /// </summary>
        /// <param name="attributes">
        ///     The polygon attributes to set.
        /// </param>
        public virtual DotNodeAttributes SetPolygonal(DotPolygon attributes)
        {
            Shape = DotNodeShape.Polygon;
            Geometry.Set(attributes);
            return this;
        }
    }
}