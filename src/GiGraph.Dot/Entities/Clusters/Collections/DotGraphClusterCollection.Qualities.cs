using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Graphs.Style;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Clusters.Collections;

public partial class DotGraphClusterCollection : IDotStripeFillable
{
    void IDotFillable.SetFillStyle(DotFillStyle style) => Style.FillStyle = (DotGraphFillStyle) style;
    void IDotFillable.SetFillColor(DotColorDefinition color) => Style.FillColor = color;
    void IDotFillable.SetGradientFillAngle(int? angle) => ((IDotGraphRootAttributes) _graphAttributes).Style.GradientFillAngle = angle;
}