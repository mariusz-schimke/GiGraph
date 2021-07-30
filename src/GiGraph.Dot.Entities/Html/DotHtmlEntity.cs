using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Labels;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Represents an HTML entity.
    /// </summary>
    public abstract class DotHtmlEntity : IDotHtmlEntity
    {
        /// <inheritdoc cref="IDotHtmlEntity.ToHtml()" />
        public virtual DotHtmlString ToHtml()
        {
            return ToHtml(DotSyntaxOptions.Default, DotSyntaxRules.Default);
        }

        public DotHtmlLabel ToLabel()
        {
            return new DotHtmlLabel(this);
        }

        string IDotHtmlEncodable.ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return ToHtml(options, syntaxRules);
        }

        protected abstract string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules);
    }
}