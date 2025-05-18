namespace GiGraph.Dot.Types.Html.Table;

/// <summary>
///     The corner style of an HTML table or cell.
/// </summary>
public enum DotHtmlTableCornerStyle
{
    /// <summary>
    ///     The table will have sharp corners.
    /// </summary>
    Sharp = DotHtmlTableStyles.Default,

    /// <inheritdoc cref="DotHtmlTableStyles.Rounded"/>
    Rounded = DotHtmlTableStyles.Rounded
}