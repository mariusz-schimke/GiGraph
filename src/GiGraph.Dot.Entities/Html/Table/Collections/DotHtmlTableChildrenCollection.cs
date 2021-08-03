using System;

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
    }
}