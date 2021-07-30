using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
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

        string IDotHtmlEncodable.ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return ToHtml(options, syntaxRules);
        }

        public override string ToString()
        {
            return ToHtml();
        }

        protected abstract string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules);
    }
}