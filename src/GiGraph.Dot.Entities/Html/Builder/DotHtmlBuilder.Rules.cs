using System;
using GiGraph.Dot.Entities.Html.Rule;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Appends a horizontal rule to the builder.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendHorizontalRule(Action<DotHtmlHorizontalRule> init = null)
        {
            return Append(new DotHtmlHorizontalRule(), init);
        }

        /// <summary>
        ///     Appends a vertical rule to the builder.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendVerticalRule(Action<DotHtmlVerticalRule> init = null)
        {
            return Append(new DotHtmlVerticalRule(), init);
        }
    }
}