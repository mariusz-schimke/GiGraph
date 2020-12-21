using System;
using System.Collections.Generic;
using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Types.Html.Table
{
    /// <summary>
    ///     An HTML table row.
    /// </summary>
    public class DotHtmlTableRow : DotHtmlElement
    {
        /// <summary>
        ///     Initializes a new table row instance.
        /// </summary>
        public DotHtmlTableRow()
            : base("TR")
        {
        }

        public DotEscapeString Id { get; set; }
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
        ///     Adds a cell to the current row.
        /// </summary>
        /// <param name="text">
        ///     The text to initialize the cell with.
        /// </param>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell AddCell(string text, Action<DotHtmlTableCell> init = null)
        {
            var rowCell = new DotHtmlTableCell();
            rowCell.Children.AddRange(FromText(text));
            return AddCell(rowCell, init);
        }

        /// <summary>
        ///     Adds the specified cells to the current row.
        /// </summary>
        /// <param name="cells">
        ///     The text for the cells to add.
        /// </param>
        public virtual DotHtmlTableCell[] AddCells(params string[] cells)
        {
            return AddCells(cells, init: null);
        }

        /// <summary>
        ///     Adds the specified cells to the current row.
        /// </summary>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        /// <param name="cells">
        ///     The text for the cells to add.
        /// </param>
        public virtual DotHtmlTableCell[] AddCells(Action<DotHtmlTableCell> init, params string[] cells)
        {
            return AddCells(cells, init);
        }

        /// <summary>
        ///     Adds the specified cells to the current row.
        /// </summary>
        /// <param name="cells">
        ///     The text for the cells to add.
        /// </param>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell[] AddCells(IEnumerable<string> cells, Action<DotHtmlTableCell> init = null)
        {
            var result = new List<DotHtmlTableCell>();

            foreach (var cell in cells)
            {
                result.Add(AddCell(cell, init));
            }

            return result.ToArray();
        }

        /// <summary>
        ///     Adds the specified cells to the current row.
        /// </summary>
        /// <param name="cell">
        ///     The cell to add.
        /// </param>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell AddCell(DotHtmlTableCell cell, Action<DotHtmlTableCell> init = null)
        {
            Children.Add(cell);
            init?.Invoke(cell);
            return cell;
        }
    }
}