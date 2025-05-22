using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public interface IDotNodeGeometryAttributes
{
    /// <summary>
    ///     Number of sides if node <see cref="IDotNodeAttributes.Shape"/> is set to <see cref="DotNodeShape.Polygon"/> (default: 4,
    ///     minimum: 0).
    /// </summary>
    int? Sides { get; set; }

    /// <summary>
    ///     If true, forces polygon to be regular, i.e., the vertices of the polygon will lie on a circle whose center is the center of
    ///     the node (default: false).
    /// </summary>
    bool? Regular { get; set; }
}