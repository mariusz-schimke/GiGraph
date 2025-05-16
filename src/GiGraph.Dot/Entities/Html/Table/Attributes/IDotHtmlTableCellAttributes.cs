namespace GiGraph.Dot.Entities.Html.Table.Attributes;

/// <summary>
///     The attributes of an HTML table cell (&lt;td&gt;).
/// </summary>
public interface IDotHtmlTableCellAttributes : IDotHtmlTableTableCellCommonAttributes
{
    /// <summary>
    ///     Specifies the number of columns spanned by the cell. The default is 1, the maximum is 65535.
    /// </summary>
    int? ColumnSpan { get; set; }

    /// <summary>
    ///     Specifies the number of rows spanned by the cell. The default is 1, the maximum is 65535.
    /// </summary>
    int? RowSpan { get; set; }
}