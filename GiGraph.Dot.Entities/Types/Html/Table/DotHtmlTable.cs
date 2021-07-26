using System;
using GiGraph.Dot.Entities.Types.Alignment;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Text;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Types.Html.Table
{
    /// <summary>
    ///     An HTML table.
    /// </summary>
    public class DotHtmlTable : DotHtmlElement
    {
        /// <summary>
        ///     Initializes a new table instance.
        /// </summary>
        public DotHtmlTable()
            : base("table")
        {
        }

        /// <summary>
        ///     Allows the user to specify a unique ID for the table.
        /// </summary>
        public virtual DotEscapeString Id { get; set; }

        /// <summary>
        ///     Attaches a port name to the object. This can be used to modify the head or tail of an edge, so that the end attaches directly
        ///     to the object.
        /// </summary>
        public virtual string PortName { get; set; }

        /// <summary>
        ///     Specifies horizontal placement. When an object is allocated more space than required, this value determines where the extra
        ///     space is placed left and right of the object. Default: <see cref="DotHorizontalAlignment.Center" />.
        /// </summary>
        [DotHtmlElementAttributeKey("align")]
        public virtual DotHorizontalAlignment? HorizontalAlignment { get; set; }

        /// <summary>
        ///     Specifies vertical placement. When an object is allocated more space than required, this value determines where the extra
        ///     space is placed above and below the object. Default: <see cref="DotVerticalAlignment.Center" />.
        /// </summary>
        [DotHtmlElementAttributeKey("valign")]
        public virtual DotVerticalAlignment? VerticalAlignment { get; set; }

        /// <summary>
        ///     Sets the color of the background. This color can be overridden by a the same attribute in descendents. The value can be a
        ///     single color (<see cref="System.Drawing.Color" />) or a gradient color (<see cref="DotGradientColor" />).
        /// </summary>
        public virtual DotColorDefinition BackgroundColor { get; set; }

        /// <summary>
        ///     Sets the border color of the table. It can be overridden by the same attribute in descendents. By default, the border color
        ///     is determined by the color attribute of the corresponding node, edge or graph.
        /// </summary>
        public virtual DotColorDefinition BorderColor { get; set; }

        /// <summary>
        ///     Specifies the width of the border around the object in points. A value of zero indicates no border. The default is 1. The
        ///     maximum value is 255. If set in, and <see cref="CellBorderWidth" /> is not set, this value is also used for all cells in the
        ///     table. It can be overridden by a corresponding tag in a cell.
        /// </summary>
        public virtual int? BorderWidth { get; set; }

        /// <summary>
        ///     Specifies the width of the border for all cells in a table. It can be overridden in a cell. The maximum value is 255.
        /// </summary>
        public virtual int? CellBorderWidth { get; set; }

        /// <summary>
        ///     Specifies the space, in points, between a cell's border and its content. The default is 2. The maximum value is 255.
        /// </summary>
        public virtual int? CellPadding { get; set; }

        /// <summary>
        ///     Specifies the space, in points, between cells in a table and between a cell and the table's border. The default is 2. The
        ///     maximum value is 127.
        /// </summary>
        public virtual int? CellSpacing { get; set; }

        /// <summary>
        ///     Provides general formatting information concerning the rows. At present, the only legal value is "*", which causes a
        ///     horizontal rule to appear between every row.
        /// </summary>
        public virtual string RowFormat { get; set; }

        /// <summary>
        ///     Provides general formatting information concerning the columns. At present, the only legal value is "*", which causes a
        ///     vertical rule to appear between every cell in every row.
        /// </summary>
        public virtual int? ColumnFormat { get; set; }

        /// <summary>
        ///     Specifies which sides of a border in a cell or table should be drawn, if a border is drawn. By default, all sides are drawn.
        ///     Multiple flags may be specified.
        /// </summary>
        public virtual DotHtmlTableSides? Sides { get; set; }

        /// <summary>
        ///     Specifies whether the values given by the <see cref="Width" /> and <see cref="Height" /> attributes are enforced.
        /// </summary>
        [DotHtmlElementAttributeKey("fixedsize")]
        public virtual bool? FixedSize { get; set; }

        /// <summary>
        ///     Gives the angle used in a gradient fill if the <see cref="BackgroundColor" /> is a gradient color. For the default linear
        ///     gradient, this specifies the angle of a line through the center along which the colors transform. Thus, an angle of 0 will
        ///     cause a left-to-right progression. For radial gradients (see <see cref="Style" />), the angle specifies the position of the
        ///     center of the coloring. An angle of 0 places the center at the center of the table or cell; an non-zero angle places the fill
        ///     center along that angle near the boundary.
        /// </summary>
        public virtual int? GradientFillAngle { get; set; }

        /// <summary>
        ///     Specifies the mininum width, in points, of the object. The width includes the contents, any spacing and the border. Unless
        ///     <see cref="FixedSize" /> is true, the width will be expanded to allow the contents to fit. The maximum value is 65535.
        /// </summary>
        public virtual int? Width { get; set; }

        /// <summary>
        ///     Specifies the mininum height, in points, of the object. The height includes the contents, any spacing and the border. Unless
        ///     <see cref="FixedSize" /> is true, the height will be expanded to allow the contents to fit. The maximum value is 65535.
        /// </summary>
        public virtual int? Height { get; set; }

        /// <summary>
        ///     Attaches a URL to the object.
        /// </summary>
        public virtual DotEscapeString Href { get; set; }

        /// <summary>
        ///     Determines which window of the browser is used for the URL if the object has one. See
        ///     <see href="http://www.w3.org/TR/html401/present/frames.html#adef-target">
        ///         W3C documentation
        ///     </see>
        ///     .
        /// </summary>
        public virtual DotEscapeString Target { get; set; }

        /// <summary>
        ///     Sets the tooltip annotation attached to the element. This is used only if the element has a <see cref="Href" /> attribute.
        /// </summary>
        public virtual DotEscapeString Title { get; set; }

        /// <summary>
        ///     Sets the tooltip annotation attached to the element. This is used only if the element has a <see cref="Href" /> attribute. It
        ///     is an alias for <see cref="Title" />.
        /// </summary>
        public virtual DotEscapeString Tooltip { get; set; }

        /// <summary>
        ///     <para>
        ///         Specifies style characteristics of the table or cell. Style characteristics are given as a comma or space separated list
        ///         of style attributes. At present, the only legal attributes are "ROUNDED" and "RADIAL" for tables, and "RADIAL" for cells.
        ///         If "ROUNDED" is specified, the table will have rounded corners. This probably works best if the outmost cells have no
        ///         borders, or their <see cref="CellSpacing" /> is sufficiently large. If it is desirable to have borders around the cells,
        ///         use HR and VR elements, or the <see cref="ColumnFormat" /> and <see cref="RowFormat" /> attributes of the table.
        ///     </para>
        ///     <para>
        ///         The "RADIAL" attribute indicates a radial gradient fill. See the <see cref="BackgroundColor" /> and
        ///         <see cref="GradientFillAngle" /> attributes.
        ///     </para>
        /// </summary>
        public virtual DotHtmlTableStyles? Style { get; set; }

        /// <summary>
        ///     Adds a new row to the table and optionally initializes it.
        /// </summary>
        /// <param name="row">
        ///     The row to add.
        /// </param>
        /// <param name="init">
        ///     A row initializer delegate.
        /// </param>
        public virtual DotHtmlTableRow AddRow(DotHtmlTableRow row, Action<DotHtmlTableRow> init = null)
        {
            Children.Add(row);
            init?.Invoke(row);
            return row;
        }

        /// <summary>
        ///     Adds a new row to the table and optionally initializes it.
        /// </summary>
        /// <param name="init">
        ///     A row initializer delegate.
        /// </param>
        public virtual DotHtmlTableRow AddRow(Action<DotHtmlTableRow> init = null)
        {
            return AddRow(new DotHtmlTableRow(), init);
        }
    }
}