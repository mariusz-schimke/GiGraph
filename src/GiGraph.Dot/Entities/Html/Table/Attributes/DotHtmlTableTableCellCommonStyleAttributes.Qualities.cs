using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public partial class DotHtmlTableTableCellCommonStyleAttributes<TIHtmlTableTableCellStyleAttributeProperties, THtmlTableTableCellStyleAttributeProperties> : IDotFillable
{
    void IDotFillable.SetFillStyle(DotFillStyle style) => RadialFill = style == DotFillStyle.Radial;
    void IDotFillable.SetFillColor(DotColorDefinition color) => BackgroundColor = color;
    void IDotFillable.SetGradientFillAngle(int? angle) => GradientFillAngle = angle;
}