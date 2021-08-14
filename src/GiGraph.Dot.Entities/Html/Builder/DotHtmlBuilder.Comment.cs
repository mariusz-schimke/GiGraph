namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Appends a comment to this instance.
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