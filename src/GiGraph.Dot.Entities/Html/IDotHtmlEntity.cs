using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Represents an HTML entity.
    /// </summary>
    public interface IDotHtmlEntity
    {
        /// <summary>
        ///     Converts the entity to HTML.
        /// </summary>
        /// <param name="options">
        ///     The syntax options to apply.
        /// </param>
        /// <param name="syntaxRules">
        ///     The syntax rules to apply.
        /// </param>
        DotHtmlString ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

        /// <summary>
        ///     Converts the entity to HTML with default syntax and formatting rules.
        /// </summary>
        DotHtmlString ToHtml();
    }
}