namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Appends a comment to the builder.
        /// </summary>
        /// <param name="text">
        ///     The comment to append.
        /// </param>
        public virtual DotHtmlBuilder AppendComment(string text)
        {
            return AppendEntity(new DotHtmlComment(text));
        }
    }
}