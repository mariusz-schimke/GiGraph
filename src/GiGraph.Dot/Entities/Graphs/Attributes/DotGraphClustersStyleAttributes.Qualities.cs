using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Clusters.Style;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphClustersStyleAttributes : IDotStripeFillable
{
    void IDotFillable.SetFillStyle(DotFillStyle style) => FillStyle = (DotClusterFillStyle) style;
    void IDotFillable.SetFillColor(DotColorDefinition color) => FillColor = color;
    void IDotFillable.SetGradientFillAngle(int? angle) => _graphStyleAttributes.GradientFillAngle = angle;
}