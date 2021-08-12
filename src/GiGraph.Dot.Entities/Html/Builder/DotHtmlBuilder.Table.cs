using System;
using GiGraph.Dot.Entities.Html.Table;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Initializes and appends a table.
        /// </summary>
        /// <param name="init">
        ///     A table initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendTable(Action<DotHtmlTable> init)
        {
            return AppendEntity(new DotHtmlTable(), init);
        }
    }
}