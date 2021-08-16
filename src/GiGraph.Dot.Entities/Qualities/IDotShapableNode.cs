using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Entities.Qualities
{
    public interface IDotShapableNode
    {
        void SetShape(DotNodeShape shape);
        void SetGeometry(DotPolygon geometry);
    }
}