using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Html.Table;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html.Table.Attributes
{
    /// <summary>
    ///     The attributes of an HTML table cell.
    /// </summary>
    public interface IDotHtmlTableCellAttributes : IDotHtmlTableTableCellCommonAttributes
    {
        /// <summary>
        ///     Specifies horizontal placement. When an object is allocated more space than required, this value determines where the extra
        ///     space is placed left and right of the object. Default: <see cref="DotHorizontalAlignment.Center" />.
        /// </summary>
        DotHorizontalCellAlignment? HorizontalAlignment { get; set; }

        // ALIGN
        // BALIGN
        // COLSPAN
        // ROWSPAN
    }
}