using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Nodes.Collections;

public partial class DotNodeCollection : IDotShapableNode, IDotStripeFillable, IDotWedgeFillable
{
    void IDotShapableNode.SetShape(DotNodeShape shape) => Shape = shape;
    void IDotShapableNode.SetGeometry(DotPolygon geometry) => Geometry.Set(geometry);
    void IDotFillable.SetFillStyle(DotFillStyle style) => Style.FillStyle = (DotNodeFillStyle) style;
    void IDotFillable.SetFillColor(DotColorDefinition color) => FillColor = color;
    void IDotFillable.SetGradientFillAngle(int? angle) => GradientFillAngle = angle;
}