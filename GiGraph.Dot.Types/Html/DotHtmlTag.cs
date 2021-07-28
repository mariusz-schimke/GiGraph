using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Types.Html
{
    /// <summary>
    ///     Represents an HTML tag.
    /// </summary>
    public abstract class DotHtmlTag : IDotHtmlEntity
    {
        protected readonly bool _isVoid;
        protected readonly string _name;

        protected DotHtmlTag(string name, bool isVoid)
        {
            _name = name;
            _isVoid = isVoid;
            CustomAttributes = new Dictionary<string, object>();
        }

        /// <summary>
        ///     Gets the attributes of the element tag.
        /// </summary>
        public virtual Dictionary<string, object> CustomAttributes { get; }

        /// <inheritdoc cref="IDotHtmlEntity" />
        public DotHtml ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            var result = new StringBuilder();

            var attrs = GetAttributes(options, syntaxRules)
               .Select(attr =>
                    $"{(options.Attributes.Html.UpperCaseAttributeNames ? attr.Key.ToUpperInvariant() : attr.Key)}=\"{attr.Value}\""
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

                result.Append($"</{_name}>");
            }

            return result.ToString();
        }

        protected virtual IEnumerable<IDotHtmlEntity> GetChildren()
        {
            return Enumerable.Empty<IDotHtmlEntity>();
        }

        protected virtual Dictionary<string, string> GetAttributes(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            var attributes = GetType()
               .GetProperties(BindingFlags.Instance | BindingFlags.Public)
               .Select(prop =>
                {
                    var attribute = prop.GetCustomAttribute<DotHtmlElementAttributeKeyAttribute>();
                    if (attribute is null)
                    {
                        return null;
                    }

                    var value = prop.GetValue(this);
                    if (value is null)
                    {
                        return null;
                    }

                    var converter = syntaxRules.Attributes.Html.GetAttributeValueConverterForValue(value);
                    return new
                    {
                        attribute.Key,
                        Value = converter.Convert(value, options, syntaxRules)
                    };
                })
               .Where(attr => attr is not null)
               .ToDictionary(key => key.Key, value => value.Value);

            // add custom attributes
            var customAttributes = CustomAttributes.Where(attribute => !attributes.ContainsKey(attribute.Key));
            foreach (var attribute in customAttributes)
            {
                var converter = syntaxRules.Attributes.Html.GetAttributeValueConverterForValue(attribute.Value);
                attributes[attribute.Key] = converter.Convert(attribute.Value, options, syntaxRules);
            }

            return attributes;
        }
    }
}