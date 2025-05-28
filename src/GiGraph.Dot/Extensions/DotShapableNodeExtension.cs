using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Extensions;

public static class DotShapableNodeExtension
{
    /// <summary>
    ///     Applies a polygonal shape.
    /// </summary>
    /// <param name="node">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="sides">
    ///     The number of sides (default: 4, minimum: 0).
    /// </param>
    /// <param name="regular">
    ///     If true, forces polygon to be regular, i.e., the vertices of the polygon will lie on a circle whose center is the center of
    ///     the node (default: false).
    /// </param>
    public static T SetPolygonalShape<T>(this T node, int? sides, bool? regular)
        where T : IDotShapableNode =>
        node.SetPolygonalShape(new DotPolygon(sides, regular));

    /// <summary>
    ///     Applies a polygonal shape.
    /// </summary>
    /// <param name="node">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="attributes">
    ///     The polygon attributes to set.
    /// </param>
    public static T SetPolygonalShape<T>(this T node, DotPolygon attributes)
        where T : IDotShapableNode
    {
        node.SetShape(DotNodeShape.Polygon);
        node.SetGeometry(attributes);
        return node;
    }
}