using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Qualities;

public interface IDotHasBorderStyleAttributes
{
    DotColorDefinition? Color { get; set; }
    double? BorderWidth { get; set; }
}