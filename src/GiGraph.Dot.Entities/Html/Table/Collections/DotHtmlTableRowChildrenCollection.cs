using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Html.Text;

namespace GiGraph.Dot.Entities.Html.Table.Collections
{
    public class DotHtmlTableRowChildrenCollection : DotHtmlEntityCollection
    {
        /// <summary>
        ///     Adds the specified cells to the current row.
        /// </summary>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell AddCell(Action<DotHtmlTableCell> init = null)
        {
            return Add(new DotHtmlTableCell(), init);
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
            var cell = new DotHtmlTableCell
            {
                Children =
                {
                    new DotHtmlText(text)
                }
            };

            return Add(cell, init);
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
            return cells.Select(cell => AddCell(cell, init)).ToArray();
        }
    }
}