using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Contains ready HTML text to be rendered as is, without further processing.
    /// </summary>
    public class DotHtml : DotHtmlEntity
    {
        protected readonly DotHtmlString _html;

        /// <summary>
        ///     Initializes a new instance with the specified HTML.
        /// </summary>
        /// <param name="html">
        ///     The HTML to initialize the instance with.
        /// </param>
        public DotHtml(DotHtmlString html)
        {
            _html = html;
        }

        protected internal override string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => _html;
    }
}