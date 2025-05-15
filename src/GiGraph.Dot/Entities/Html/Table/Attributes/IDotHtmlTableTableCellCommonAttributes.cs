using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

/// <summary>
///     The common attributes of an HTML table (&lt;table&gt;) and an HTML table cell (&lt;td&gt;).
/// </summary>
public interface IDotHtmlTableTableCellCommonAttributes
{
    /// <summary>
    ///     Allows the user to specify a unique ID for the table.
    /// </summary>
    DotEscapeString? Id { get; set; }

    /// <summary>
    ///     Attaches a port name to the object. This can be used to modify the head or tail of an edge, so that the end attaches directly
    ///     to the object.
    /// </summary>
    string? PortName { get; set; }

    /// <summary>
    ///     Specifies vertical placement. When an object is allocated more space than required, this value determines where the extra
    ///     space is placed above and below the object. Default: <see cref="DotVerticalAlignment.Center"/>.
    /// </summary>
    DotVerticalAlignment? VerticalAlignment { get; set; }

    /// <summary>
    ///     Specifies the space, in points, between a cell's border and its content. The default is 2. The maximum value is 255.
    /// </summary>
    int? CellPadding { get; set; }

    /// <summary>
    ///     Specifies the space, in points, between cells in a table and between a cell and the table's border. The default is 2. The
    ///     maximum value is 127.
    /// </summary>
    int? CellSpacing { get; set; }

    /// <summary>
    ///     Specifies which sides of a border in a cell or table should be drawn, if a border is drawn. By default, all sides are drawn.
    ///     Multiple flags may be specified.
    /// </summary>
    DotHtmlTableBorders? Borders { get; set; }
}