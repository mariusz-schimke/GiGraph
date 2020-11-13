using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public interface IDotNodeGeometryAttributes
    {
        /// <summary>
        ///     Number of sides if node <see cref="DotNodeAttributes.Shape" /> is set to <see cref="DotNodeShape.Polygon" /> (default: 4,
        ///     minimum: 0).
        /// </summary>
        int? Sides { get; set; }

        /// <summary>
        ///     If true, forces polygon to be regular, i.e., the vertices of the polygon will lie on a circle whose center is the center of
        ///     the node (default: false).
        /// </summary>
        bool? Regular { get; set; }

        /// <summary>
        ///     Sets the number of peripheries used in polygonal node shapes (<see cref="DotNodeAttributes.Shape" />). The default value is
        ///     shape dependent, the minimum value is 0. Note that user-defined shapes (see
        ///     <see href="http://www.graphviz.org/doc/info/shapes.html#epsf">
        ///         documentation
        ///     </see>
        ///     ) are treated as a form of box shape, so the default peripheries value is 1, and the user-defined shape will be drawn in a
        ///     bounding rectangle. Setting peripheries to 0 will turn this off.
        /// </summary>
        int? Peripheries { get; set; }

        /// <summary>
        ///     Angle, in degrees, used to rotate polygon node shapes (<see cref="DotNodeAttributes.Shape" /> =
        ///     <see cref="DotNodeShape.Polygon" />). For any number of polygon sides, 0 degrees rotation results in a flat base. Default: 0,
        ///     maximum: 360.
        /// </summary>
        double? Rotation { get; set; }

        /// <summary>
        ///     Skew factor for node <see cref="DotNodeAttributes.Shape" /> set to <see cref="DotNodeShape.Polygon" /> (default: 0, minimum:
        ///     -100). Positive values skew top of polygon to right; negative to left.
        /// </summary>
        double? Skew { get; set; }

        /// <summary>
        ///     Distortion factor for node <see cref="DotNodeAttributes.Shape" /> set to <see cref="DotNodeShape.Polygon" /> (default: 0,
        ///     minimum: -100). Positive values cause top part to be larger than bottom; negative values do the opposite.
        /// </summary>
        double? Distortion { get; set; }
    }
}