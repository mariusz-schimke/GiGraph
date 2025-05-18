using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public partial class DotEdgeStyleAttributes : IDotStylableEdge
{
    void IDotStylableEdge.SetLineStyle(DotLineStyle style) => LineStyle = style;
    void IDotStylableEdge.SetLineColor(DotColorDefinition color) => LineColor = color;
    void IDotStylableEdge.SetLineWidth(double? width) => LineWidth = width;
}