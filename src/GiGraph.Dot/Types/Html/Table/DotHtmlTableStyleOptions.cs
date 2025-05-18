namespace GiGraph.Dot.Types.Html.Table;

/// <summary>
///     HTML table or table cell style options.
/// </summary>
/// <param name="FillStyle">
///     Specifies a fill style.
/// </param>
/// <param name="CornerStyle">
///     Specifies a corner style.
/// </param>
public record DotHtmlTableStyleOptions(DotHtmlTableFillStyle FillStyle = default, DotHtmlTableCornerStyle CornerStyle = default);