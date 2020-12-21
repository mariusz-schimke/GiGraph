using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Html
{
    /// <summary>
    ///     Text content of an HTML element.
    /// </summary>
    public class DotHtmlText : DotHtmlEntity
    {
        /// <summary>
        ///     Initializes a new HTML text instance.
        /// </summary>
        /// <param name="text">
        ///     The text to initialize the instance with.
        /// </param>
        public DotHtmlText(string text)
        {
            Text = text;
        }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        public virtual string Text { get; set; }

        public override DotHtml ToHtml()
        {
            return DotHtmlEscaper.Escape(Text);
        }
    }
}