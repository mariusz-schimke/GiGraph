using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges
{
    public abstract partial class DotEdgeDefinition : IDotStylableEdge
    {
        void IDotStylableEdge.SetStyle(DotLineStyle style) => Style.LineStyle = style;
        void IDotStylableEdge.SetColor(DotColorDefinition color) => Color = color;
        void IDotStylableEdge.SetWidth(double? width) => Width = width;
    }
}