using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes
{
    /// <summary>
    ///     The attributes of an HTML table (&lt;table&gt;).
    /// </summary>
    public interface IDotHtmlTableAttributes : IDotHtmlTableTableCellCommonAttributes
    {
        /// <summary>
        ///     Specifies horizontal placement. When an object is allocated more space than required, this value determines where the extra
        ///     space is placed left and right of the object. Default: <see cref="DotHorizontalAlignment.Center" />.
        /// </summary>
        DotHorizontalAlignment? HorizontalAlignment { get; set; }

        /// <summary>
        ///     Specifies the width of the border for all cells in a table. It can be overridden in a cell. The maximum value is 255.
        /// </summary>
        int? CellBorderWidth { get; set; }

        /// <summary>
        ///     Provides general formatting information concerning the rows. See <see cref="DotHtmlTableRowFormat" /> for accepted values.
        /// </summary>
        string RowFormat { get; set; }

        /// <summary>
        ///     Provides general formatting information concerning the columns. See <see cref="DotHtmlTableColumnFormat" /> for accepted
        ///     values.
        /// </summary>
        string ColumnFormat { get; set; }
    }
}