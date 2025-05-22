using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Entities.Nodes.Collections;

public partial class DotNodeCollection : IDotShapableNode
{
    void IDotShapableNode.SetShape(DotNodeShape shape) => Shape = shape;
    void IDotShapableNode.SetGeometry(DotPolygon geometry) => Geometry.SetGeometry(geometry);
}