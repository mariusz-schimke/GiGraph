using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public partial class DotEdgeStyleAttributes : IDotStylableEdge
{
    void IDotStylableEdge.SetStyle(DotLineStyle style) => LineStyle = style;
    void IDotStylableEdge.SetColor(DotColorDefinition color) => Color = color;
    void IDotStylableEdge.SetWidth(double? width) => LineWidth = width;
}