using GiGraph.Dot.Entities.Html.Rule;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Appends a horizontal rule to the builder.
        /// </summary>
        public virtual DotHtmlBuilder AppendHorizontalRule()
        {
            return Append(new DotHtmlHorizontalRule());
        }

        /// <summary>
        ///     Appends a vertical rule to the builder.
        /// </summary>
        public virtual DotHtmlBuilder AppendVerticalRule()
        {
            return Append(new DotHtmlVerticalRule());
        }
    }
}