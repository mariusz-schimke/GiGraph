using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     An HTML entity represented by ready HTML text, to be rendered as is.
    /// </summary>
    public class DotCustomHtml : DotHtmlEntity
    {
        protected readonly DotHtmlString _html;

        /// <summary>
        ///     Initializes a new instance with the specified HTML.
        /// </summary>
        /// <param name="html">
        ///     The HTML to initialize the instance with.
        /// </param>
        public DotCustomHtml(DotHtmlString html)
        {
            _html = html;
        }

        protected internal override string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => _html;
    }
}