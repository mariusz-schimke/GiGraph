using System;
using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Html
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
            : base("TABLE")
        {
        }

        public string Id { get; set; }
        public string PortName { get; set; }
        public string Title { get; set; }
        public string Tooltip { get; set; }
        public DotHorizontalAlignment? HorizontalAlignment { get; set; }
        public DotVerticalAlignment? VerticalAlignment { get; set; }
        public Color? BackgroundColor { get; set; }
        public Color? Color { get; set; }
        public int? BorderWidth { get; set; }
        public int? CellBorder { get; set; }
        public int? CellPadding { get; set; }
        public int? CellSpacing { get; set; }
        public string RowsA { get; set; }
        public int? Columns { get; set; }
        public int? Sides { get; set; }
        public bool? FixedSize { get; set; }
        public int? GradientFillAngle { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public int? Href { get; set; }
        public int? Target { get; set; }
        public string Style { get; set; }

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