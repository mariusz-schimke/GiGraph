namespace GiGraph.Dot.Types.Html.Table;

/// <summary>
///     The corner style of an HTML table or cell.
/// </summary>
public enum DotHtmlTableCornerStyle
{
    /// <summary>
    ///     A sharp corner style. Note that this is not an explicit corner style setting but rather expresses a lack of style
    ///     specification, so the default style will be used (sharp).
    /// </summary>
    Sharp = DotHtmlTableStyles.Default,

    /// <inheritdoc cref="DotHtmlTableStyles.Rounded"/>
    Rounded = DotHtmlTableStyles.Rounded
}