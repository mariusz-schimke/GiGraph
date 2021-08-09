using System.Collections.Generic;
using System.Linq;
using System.Text;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Represents an HTML tag with optional attributes.
    /// </summary>
    public abstract class DotHtmlTag : DotHtmlEntity
    {
        protected readonly string _name;

        protected DotHtmlTag(string name, DotAttributeCollection attributes)
        {
            _name = name;
            Attributes = attributes;
        }

        /// <summary>
        ///     Gets the collection of attributes of the element.
        /// </summary>
        public virtual DotAttributeCollection Attributes { get; }

        protected abstract bool IsVoid { get; }

        protected internal override string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            var result = new StringBuilder();

            var attrs = Attributes.Values
               .Select(attr =>
                    $"{(options.Attributes.Html.UpperCaseAttributeNames ? attr.Key.ToUpperInvariant() : attr.Key)}=\"{attr.GetDotEncodedValue(options, syntaxRules)}\""
                );

            var tagName = options.Attributes.Html.UpperCaseTagNames ? _name.ToUpperInvariant() : _name;
            var tagWithAttributes = string.Join(
                " ",
                Enumerable.Empty<string>()
                   .Append($"<{tagName}")
                   .Concat(attrs)
            );

            result.Append(tagWithAttributes);

            if (IsVoid)
            {
                result.Append("/>");
            }
            else
            {
                result.Append(">");

                var children = GetContent().Select(child => child.ToHtml(options, syntaxRules));
                result.Append(string.Join(string.Empty, children));

                result.Append($"</{tagName}>");
            }

            return result.ToString();
        }

        protected virtual IEnumerable<IDotHtmlEntity> GetContent()
        {
            return Enumerable.Empty<IDotHtmlEntity>();
        }
    }
}