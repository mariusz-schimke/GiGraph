using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Extensions;

public static class DotShapableNodeExtension
{
    /// <summary>
    ///     Applies a polygonal shape.
    /// </summary>
    /// <param name="this">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="sides">
    ///     The number of sides (default: 4, minimum: 0).
    /// </param>
    /// <param name="regular">
    ///     If true, forces polygon to be regular, i.e., the vertices of the polygon will lie on a circle whose center is the center of
    ///     the node (default: false).
    /// </param>
    /// <param name="peripheries">
    ///     Sets the number of peripheries. The default value is shape dependent, the minimum value is 0. Note that
    ///     <see href="http://www.graphviz.org/doc/info/shapes.html#epsf">
    ///         user-defined shapes
    ///     </see>
    ///     are treated as a form of box shape, so the default peripheries value is 1, and the user-defined shape will be drawn in a
    ///     bounding rectangle. Setting peripheries to 0 will turn this off.
    /// </param>
    /// <param name="rotation">
    ///     Angle, in degrees, used to rotate the polygon. For any number of polygon sides, 0 degrees rotation results in a flat base.
    ///     Default: 0, maximum: 360.
    /// </param>
    /// <param name="skew">
    ///     Skew factor (default: 0, minimum: -100). Positive values skew top of polygon to right; negative to left.
    /// </param>
    /// <param name="distortion">
    ///     Distortion factor (default: 0, minimum: -100). Positive values cause top part to be larger than bottom; negative values do
    ///     the opposite.
    /// </param>
    public static void SetPolygonalShape<T>(
        this T @this,
        int? sides = null,
        bool? regular = null,
        int? peripheries = null,
        double? rotation = null,
        double? skew = null,
        double? distortion = null
    )
        where T : IDotShapableNode
    {
        @this.SetPolygonalShape(new DotPolygon(sides, regular, peripheries, rotation, skew, distortion));
    }

    /// <summary>
    ///     Applies a polygonal shape.
    /// </summary>
    /// <param name="this">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="attributes">
    ///     The polygon attributes to set.
    /// </param>
    public static void SetPolygonalShape<T>(this T @this, DotPolygon attributes)
        where T : IDotShapableNode
    {
        @this.SetShape(DotNodeShape.Polygon);
        @this.SetGeometry(attributes);
    }
}