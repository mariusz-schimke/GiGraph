using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Html.Table;

public partial class DotHtmlTable : IDotFillable
{
    void IDotFillable.SetFillStyle(DotFillStyle style) => Style.RadialFill = style == DotFillStyle.Radial;
    void IDotFillable.SetFillColor(DotColorDefinition color) => Style.BackgroundColor = color;
    void IDotFillable.SetGradientFillAngle(int? angle) => Style.GradientFillAngle = angle;
}