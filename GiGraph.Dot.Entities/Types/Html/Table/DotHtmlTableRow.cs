using System;
using System.Collections.Generic;

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