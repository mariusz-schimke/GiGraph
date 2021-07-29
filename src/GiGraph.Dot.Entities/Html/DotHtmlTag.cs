using System.Collections.Generic;
using System.Linq;
using System.Text;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Represents an HTML tag.
    /// </summary>
    public abstract class DotHtmlTag : IDotHtmlEntity
    {
        protected readonly bool _isVoid;
        protected readonly string _name;

        protected DotHtmlTag(string name, bool isVoid, DotAttributeCollection attributes)
        {
            _name = name;
            _isVoid = isVoid;
            Attributes = attributes;
        }

        /// <summary>
        ///     Gets the collection of attributes of the element.
        /// </summary>
        public virtual DotAttributeCollection Attributes { get; }

        /// <inheritdoc cref="IDotHtmlEntity.ToHtml" />
        public DotHtml ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
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

            if (_isVoid)
            {
                result.Append("/>");
            }
            else
            {
                result.Append(">");

                var children = GetChildren().Select(child => child.ToHtml(options, syntaxRules));
                result.Append(string.Join(string.Empty, children));

                result.Append($"</{tagName}>");
            }

            return result.ToString();
        }

        /// <summary>
        ///     Converts the entity to HTML with default syntax and formatting rules.
        /// </summary>
        public virtual DotHtml ToHtml()
        {
            return ToHtml(DotSyntaxOptions.Default, DotSyntaxRules.Default);
        }

        protected virtual IEnumerable<IDotHtmlEntity> GetChildren()
        {
            return Enumerable.Empty<IDotHtmlEntity>();
        }
    }
}