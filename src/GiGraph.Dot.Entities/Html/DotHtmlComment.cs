using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Represents an HTML comment tag.
    /// </summary>
    public class DotHtmlComment : DotHtmlEntity
    {
        protected readonly string _text;

        /// <summary>
        ///     Creates a new HTML comment tag instance.
        /// </summary>
        /// <param name="text">
        ///     The comment text.
        /// </param>
        public DotHtmlComment(string text)
        {
            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }

        protected internal override string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            const string tagName = "--";
            return $"<!{tagName}{syntaxRules.Attributes.Html.CommentTextEscaper.Escape(_text)}{tagName}>";
        }
    }
}