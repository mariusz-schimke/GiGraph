using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Entities.Html.Text;

namespace GiGraph.Dot.Entities.Html.Table
{
    /// <summary>
    ///     An HTML table row (&lt;tr&gt;).
    /// </summary>
    public class DotHtmlTableRow : DotHtmlElement
    {
        /// <summary>
        ///     Initializes a new table row instance.
        /// </summary>
        public DotHtmlTableRow()
            : this(new DotAttributeCollection(DotHtmlAttributeFactory.Instance))
        {
        }

        protected DotHtmlTableRow(DotAttributeCollection attributes)
            : base("tr", attributes)
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
            var cell = new DotHtmlTableCell
            {
                Children =
                {
                    DotHtmlText.FromMultilineText(text)
                }
            };

            return AddCell(cell, init);
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

        /// <summary>
        ///     Adds the specified cells to the current row.
        /// </summary>
        /// <param name="init">
        ///     A cell initializer delegate.
        /// </param>
        public virtual DotHtmlTableCell AddCell(Action<DotHtmlTableCell> init = null)
        {
            return AddCell(new DotHtmlTableCell(), init);
        }
    }
}