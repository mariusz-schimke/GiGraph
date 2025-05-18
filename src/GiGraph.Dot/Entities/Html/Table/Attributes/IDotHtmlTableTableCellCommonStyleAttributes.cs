using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

/// <summary>
///     The common style attributes of an HTML table (&lt;table&gt;) and an HTML table cell (&lt;td&gt;).
/// </summary>
public interface IDotHtmlTableTableCellCommonStyleAttributes
{
    /// <summary>
    ///     Specifies style characteristics of the table or cell.
    /// </summary>
    DotHtmlTableStyles? Style { get; set; }

    /// <summary>
    ///     Sets the color of the background. This color can be overridden by the same attribute in descendents. The value can be a
    ///     single color (<see cref="System.Drawing.Color"/>) or a gradient color (<see cref="DotGradientColor"/>).
    /// </summary>
    DotColorDefinition? BackgroundColor { get; set; }

    /// <summary>
    ///     Sets the border color of the table or cell. It can be overridden by the same attribute in descendents. By default, the border
    ///     color is determined by the corresponding node, edge or graph.
    /// </summary>
    DotColor? BorderColor { get; set; }

    /// <summary>
    ///     Specifies the width of the border around the object in points. A value of zero indicates no border. The default is 1. The
    ///     maximum value is 255. If set in a table, and <see cref="IDotHtmlTableStyleAttributes.CellBorderWidth"/> is not set, this
    ///     value is also used for all cells in the table. It can be overridden by a corresponding attribute in a cell.
    /// </summary>
    int? BorderWidth { get; set; }

    /// <summary>
    ///     Gives the angle used in a gradient fill if the <see cref="BackgroundColor"/> is a gradient color. For the default linear
    ///     gradient, this specifies the angle of a line through the center along which the colors transform. Thus, an angle of 0 will
    ///     cause a left-to-right progression. For radial gradients (see the <see cref="DotHtmlTableStyles.Radial"/> fill style option),
    ///     the angle specifies the position of the center of the coloring. An angle of 0 places the center at the center of the table or
    ///     cell; a non-zero angle places the fill center along that angle near the boundary.
    /// </summary>
    int? GradientFillAngle { get; set; }
}