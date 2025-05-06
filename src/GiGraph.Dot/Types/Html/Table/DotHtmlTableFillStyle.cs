namespace GiGraph.Dot.Types.Html.Table;

/// <summary>
///     The fill style of an HTML table or cell.
/// </summary>
public enum DotHtmlTableFillStyle
{
    /// <summary>
    ///     Uses regular fill if a fill color is specified. This value is not an actual style option; it indicates that no fill style is
    ///     specified, allowing the renderer to use its default behavior.
    /// </summary>
    Regular = 0,

    /// <inheritdoc cref="DotHtmlTableStyles.Radial"/>
    Radial = DotHtmlTableStyles.Radial
}