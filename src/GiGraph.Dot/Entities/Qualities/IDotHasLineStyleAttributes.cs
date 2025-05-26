using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Qualities;

public interface IDotHasLineStyleAttributes
{
    DotColorDefinition? LineColor { get; set; }
    double? LineWidth { get; set; }

    DotLineStyle LineStyle { get; set; }
    DotLineWeight LineWeight { get; set; }
}