using GiGraph.Dot.Entities.Html.Rule;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Appends a horizontal rule to this instance.
        /// </summary>
        public virtual DotHtmlBuilder AppendHorizontalRule()
        {
            return AppendEntity(DotHtmlRule.Horizontal);
        }

        /// <summary>
        ///     Appends a vertical rule to this instance.
        /// </summary>
        public virtual DotHtmlBuilder AppendVerticalRule()
        {
            return AppendEntity(DotHtmlRule.Vertical);
        }
    }
}