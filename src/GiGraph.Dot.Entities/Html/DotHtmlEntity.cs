using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Represents an HTML entity.
    /// </summary>
    public abstract class DotHtmlEntity : IDotHtmlEntity
    {
        DotHtmlString IDotHtmlEntity.ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return ToHtml(options, syntaxRules);
        }

        /// <inheritdoc cref="IDotHtmlEntity.ToHtml()" />
        public virtual DotHtmlString ToHtml()
        {
            return ToHtml(DotSyntaxOptions.Default, DotSyntaxRules.Default);
        }

        /// <inheritdoc cref="IDotHtmlEntity.ToHtml(GiGraph.Dot.Output.Options.DotSyntaxOptions,GiGraph.Dot.Output.Options.DotSyntaxRules)" />
        protected abstract DotHtmlString ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules);
    }
}