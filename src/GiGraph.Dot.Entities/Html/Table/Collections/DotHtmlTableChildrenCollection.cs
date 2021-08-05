using System;
using GiGraph.Dot.Entities.Html.Rule;

namespace GiGraph.Dot.Entities.Html.Table.Collections
{
    public class DotHtmlTableChildrenCollection : DotHtmlEntityCollection
    {
        /// <summary>
        ///     Adds a new row to the table and optionally initializes it.
        /// </summary>
        /// <param name="init">
        ///     An optional row initializer delegate.
        /// </param>
        public virtual DotHtmlTableRow AddRow(Action<DotHtmlTableRow> init = null)
        {
            return Add(new DotHtmlTableRow(), init);
        }

        /// <summary>
        ///     Adds a horizontal rule to separate two neighboring rows.
        /// </summary>
        public virtual DotHtmlHorizontalRule AddHorizontalRule()
        {
            return Add(new DotHtmlHorizontalRule(), init: null);
        }
    }
}