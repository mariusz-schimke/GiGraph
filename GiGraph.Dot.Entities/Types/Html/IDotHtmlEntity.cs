using GiGraph.Dot.Entities.Types.Text;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Html
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