using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Table.Attributes
{
    /// <summary>
    ///     The attributes of an HTML table.
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
        ///     Provides general formatting information concerning the rows. At present, the only legal value is "*", which causes a
        ///     horizontal rule to appear between every row.
        /// </summary>
        string RowFormatting { get; set; }

        /// <summary>
        ///     Provides general formatting information concerning the columns. At present, the only legal value is "*", which causes a
        ///     vertical rule to appear between every cell in every row.
        /// </summary>
        string ColumnFormatting { get; set; }
    }
}