using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Nodes.Style;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public partial class DotNodeStyleAttributes : IDotStripeFillable, IDotWedgeFillable
{
    void IDotFillable.SetFillStyle(DotFillStyle style) => FillStyle = (DotNodeFillStyle) style;
    void IDotFillable.SetFillColor(DotColorDefinition color) => FillColor = color;
    void IDotFillable.SetGradientFillAngle(int? angle) => GradientFillAngle = angle;
}