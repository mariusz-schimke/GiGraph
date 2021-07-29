using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Represents an HTML entity.
    /// </summary>
    public abstract class DotHtmlEntity : IDotHtmlEntity
    {
        /// <inheritdoc cref="IDotHtmlEntity.ToHtml(GiGraph.Dot.Output.Options.DotSyntaxOptions,GiGraph.Dot.Output.Options.DotSyntaxRules)" />
        public abstract DotHtml ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

        /// <inheritdoc cref="IDotHtmlEntity.ToHtml()" />
        public virtual DotHtml ToHtml()
        {
            return ToHtml(DotSyntaxOptions.Default, DotSyntaxRules.Default);
        }
    }
}