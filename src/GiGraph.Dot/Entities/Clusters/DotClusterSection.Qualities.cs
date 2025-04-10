using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Clusters;

public partial class DotClusterSection : IDotStripeFillable
{
    void IDotFillable.SetFillStyle(DotFillStyle style) => Style.FillStyle = (DotClusterFillStyle) style;
    void IDotFillable.SetFillColor(DotColorDefinition color) => Style.FillColor = color;
    void IDotFillable.SetGradientFillAngle(int? angle) => Style.GradientFillAngle = angle;
}