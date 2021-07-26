using GiGraph.Dot.Entities.Types.Text;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Html
{
    /// <summary>
    ///     Text content of an HTML element.
    /// </summary>
    public class DotHtmlTextContent : IDotHtmlEntity
    {
        /// <summary>
        ///     Initializes a new HTML text instance.
        /// </summary>
        /// <param name="text">
        ///     The text to initialize the instance with.
        /// </param>
        public DotHtmlTextContent(string text)
        {
            Text = text;
        }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        public virtual string Text { get; set; }

        /// <inheritdoc cref="IDotHtmlEntity" />
        public DotHtml ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return syntaxRules.Attributes.Html.ElementTextContentEscaper.Escape(Text);
        }
    }
}