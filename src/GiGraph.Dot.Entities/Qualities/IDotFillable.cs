using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Qualities
{
    public interface IDotFillable
    {
        void SetFillStyle(DotFillStyle style);
        void SetFillColor(DotColorDefinition color);
        void SetGradientFillAngle(int? angle);
    }
}