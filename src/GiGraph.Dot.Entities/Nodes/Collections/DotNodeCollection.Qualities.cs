using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Nodes.Collections
{
    public partial class DotNodeCollection : IDotShapableNode, IDotStylable, IDotFillable, IDotStripable, IDotWedgeable
    {
        void IDotFillable.SetFillColor(DotColorDefinition color) => FillColor = color;
        void IDotFillable.SetGradientFillAngle(int? angle) => GradientFillAngle = angle;
        void IDotShapableNode.SetShape(DotNodeShape shape) => Shape = shape;
        void IDotShapableNode.SetGeometry(DotPolygon geometry) => Geometry.Set(geometry);
        void IDotStripable.SetStripeColors(DotMultiColor color) => FillColor = color;
        void IDotStylable.SetStyle(DotStyles style) => Attributes.Set(a => a.Style, style);
        void IDotWedgeable.SetWedgeColors(DotMultiColor color) => FillColor = color;
    }
}