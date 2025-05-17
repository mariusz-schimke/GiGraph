using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

/// <summary>
///     The attributes of an HTML table (&lt;table&gt;).
/// </summary>
public interface IDotHtmlTableAttributes : IDotHtmlTableTableCellCommonAttributes
{
    /// <summary>
    ///     Provides general formatting information concerning the rows. See <see cref="DotHtmlTableRowFormat"/> for accepted values.
    /// </summary>
    string? RowFormat { get; set; }

    /// <summary>
    ///     Provides general formatting information concerning the columns. See <see cref="DotHtmlTableColumnFormat"/> for accepted
    ///     values.
    /// </summary>
    string? ColumnFormat { get; set; }
}