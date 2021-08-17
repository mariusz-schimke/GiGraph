using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Qualities
{
    public interface IDotStylableEdge
    {
        void SetStyle(DotLineStyle style);
        void SetColor(DotColorDefinition color);
        void SetWidth(double? width);
    }
}