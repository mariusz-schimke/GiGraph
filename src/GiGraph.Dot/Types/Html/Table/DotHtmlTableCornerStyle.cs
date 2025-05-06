namespace GiGraph.Dot.Types.Html.Table;

/// <summary>
///     The corner style of an HTML table or cell.
/// </summary>
public enum DotHtmlTableCornerStyle
{
    /// <summary>
    ///     Sharp corners. This value is not an actual style option; it indicates that no corner style is specified, allowing the
    ///     renderer to use its default behavior.
    /// </summary>
    Sharp = 0,

    /// <inheritdoc cref="DotHtmlTableStyles.Rounded"/>
    Rounded = DotHtmlTableStyles.Rounded
}