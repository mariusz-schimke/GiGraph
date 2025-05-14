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

    /// <summary>
    ///     Specifies whether the values given by the <see cref="Width"/> and <see cref="Height"/> attributes are enforced. False allows
    ///     the object to grow so that all its contents will fit (default). True fixes the object size to its given <see cref="Width"/>
    ///     and <see cref="Height"/>. Both of these attributes must be supplied.
    /// </summary>
    bool? FixedSize { get; set; }

    /// <summary>
    ///     Specifies the mininum width, in points, of the object. The width includes the contents, any spacing and the border. Unless
    ///     <see cref="FixedSize"/> is true, the width will be expanded to allow the contents to fit. The maximum value is 65535.
    /// </summary>
    int? Width { get; set; }

    /// <summary>
    ///     Specifies the mininum height, in points, of the object. The height includes the contents, any spacing and the border. Unless
    ///     <see cref="FixedSize"/> is true, the height will be expanded to allow the contents to fit. The maximum value is 65535.
    /// </summary>
    int? Height { get; set; }

    /// <summary>
    ///     Attaches a URL to the object.
    /// </summary>
    DotEscapeString? Href { get; set; }

    /// <summary>
    ///     Determines which window of the browser is used for the URL if the object has one. See
    ///     <see href="http://www.w3.org/TR/html401/present/frames.html#adef-target">
    ///         W3C documentation
    ///     </see>
    ///     .
    /// </summary>
    DotEscapeString? Target { get; set; }

    /// <summary>
    ///     Sets the tooltip annotation attached to the element. This is used only if the element has a <see cref="Href"/> attribute.
    /// </summary>
    DotEscapeString? Title { get; set; }

    /// <summary>
    ///     Sets the tooltip annotation attached to the element. This is used only if the element has a <see cref="Href"/> attribute. It
    ///     is an alias for <see cref="Title"/>.
    /// </summary>
    DotEscapeString? Tooltip { get; set; }
}