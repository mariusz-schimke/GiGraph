using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Collections;

public partial class DotEdgeCollection : IDotStylableEdge
{
    void IDotStylableEdge.SetStyle(DotLineStyle style) => Style.LineStyle = style;
    void IDotStylableEdge.SetColor(DotColorDefinition color) => Style.Color = color;
    void IDotStylableEdge.SetWidth(double? width) => Style.Width = width;
}