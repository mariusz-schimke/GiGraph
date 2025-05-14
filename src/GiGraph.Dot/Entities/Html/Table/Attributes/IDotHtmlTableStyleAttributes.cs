namespace GiGraph.Dot.Entities.Html.Table.Attributes;

/// <summary>
///     The style attributes of an HTML table (&lt;table&gt;).
/// </summary>
public interface IDotHtmlTableStyleAttributes : IDotHtmlTableTableCellCommonStyleAttributes
{
    /// <summary>
    ///     Specifies the width of the border for all cells in a table. It can be overridden in a cell. The maximum value is 255.
    /// </summary>
    int? CellBorderWidth { get; set; }
}