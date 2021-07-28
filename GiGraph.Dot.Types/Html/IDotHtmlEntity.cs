using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Types.Html
{
    /// <summary>
    ///     Represents an HTML entity.
    /// </summary>
    public interface IDotHtmlEntity
    {
        /// <summary>
        ///     Converts the entity to HTML.
        /// </summary>
        public abstract DotHtml ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules);
    }
}