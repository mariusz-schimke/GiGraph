using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Represents an HTML comment tag.
    /// </summary>
    public class DotHtmlComment : DotHtmlEntity
    {
        /// <summary>
        ///     Creates a new HTML comment tag instance.
        /// </summary>
        /// <param name="text">
        ///     The comment text.
        /// </param>
        public DotHtmlComment(string text)
        {
            Text = text;
        }

        /// <summary>
        ///     The comment text.
        /// </summary>
        public virtual string Text { get; set; }

        public override DotHtmlString ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            const string tagName = "--";
            return $"<!{tagName}{syntaxRules.Attributes.Html.ElementTextContentEscaper.Escape(Text)}{tagName}>";
        }

        protected virtual IEnumerable<IDotHtmlEntity> GetChildren()
        {
            return Enumerable.Empty<IDotHtmlEntity>();
        }
    }
}