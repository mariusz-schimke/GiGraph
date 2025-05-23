using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Qualities;

public interface IDotHasBorderStyleAttributes
{
    DotColorDefinition? Color { get; set; }
    double? BorderWidth { get; set; }

    DotBorderStyle BorderStyle { get; set; }
    DotBorderWeight BorderWeight { get; set; }
}