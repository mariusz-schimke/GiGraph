namespace GiGraph.Dot.Types.Html.Table;

/// <summary>
///     The fill style of an HTML table or cell.
/// </summary>
public enum DotHtmlTableFillStyle
{
    /// <summary>
    ///     A regular fill when a background color is specified. Note that this is not an explicit fill style setting but rather
    ///     expresses a lack of style specification, so the default style will be used (sharp).
    /// </summary>
    Regular = DotHtmlTableStyles.Default,

    /// <inheritdoc cref="DotHtmlTableStyles.Radial"/>
    Radial = DotHtmlTableStyles.Radial
}