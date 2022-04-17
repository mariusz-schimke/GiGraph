using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Entities.Qualities;

public interface IDotShapableNode
{
    /// <summary>
    ///     Sets the shape of the node.
    /// </summary>
    /// <param name="shape">
    ///     The shape to set.
    /// </param>
    void SetShape(DotNodeShape shape);

    /// <summary>
    ///     Sets the geometry of the node.
    /// </summary>
    /// <param name="geometry">
    ///     The geometry to set.
    /// </param>
    void SetGeometry(DotPolygon geometry);
}