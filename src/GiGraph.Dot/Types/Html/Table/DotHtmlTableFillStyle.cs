namespace GiGraph.Dot.Types.Html.Table;

/// <summary>
///     The fill style of an HTML table or cell.
/// </summary>
public enum DotHtmlTableFillStyle
{
    /// <summary>
    ///     A regular fill when a background color is specified.
    /// </summary>
    Regular = DotHtmlTableStyles.Default,

    /// <inheritdoc cref="DotHtmlTableStyles.Radial"/>
    Radial = DotHtmlTableStyles.Radial
}