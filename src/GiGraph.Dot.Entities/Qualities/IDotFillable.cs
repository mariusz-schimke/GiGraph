using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Qualities
{
    public interface IDotFillable
    {
        void SetFillColor(DotColorDefinition color);
        void SetGradientFillAngle(int? angle);
    }
}