using System.Collections.Generic;
using System.Linq;
using System.Text;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Represents an HTML tag with optional attributes.
    /// </summary>
    public class DotHtmlTag : DotHtmlEntity
    {
        protected readonly bool _isVoid;
        protected readonly string _name;

        /// <summary>
        ///     Initializes a void HTML tag with the given name.
        /// </summary>
        /// <param name="name">
        ///     The tag name to use.
        /// </param>
        public DotHtmlTag(string name)
            : this(name, isVoid: true, new DotAttributeCollection(DotHtmlAttributeFactory.Instance))
        {
        }

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

        protected virtual IEnumerable<IDotHtmlEntity> GetChildren()
        {
            return Enumerable.Empty<IDotHtmlEntity>();
        }
    }
}