using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities
{
    public interface IDotFillable
    {
        void Fill(DotColorDefinition value);
    }
}