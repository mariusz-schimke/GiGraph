using System.Collections.Generic;
using System.Linq;
using System.Text;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Types.Html
{
    /// <summary>
    ///     Represents an HTML tag.
    /// </summary>
    public abstract class DotHtmlTag : DotHtmlEntity
    {
        protected readonly bool _contentAllowed;
        protected readonly string _name;

        protected DotHtmlTag(string name, bool contentAllowed)
        {
            _name = name;
            _contentAllowed = contentAllowed;
            Attributes = new Dictionary<string, DotHtmlAttribute>();
        }

        /// <summary>
        ///     Gets the attributes of the element tag.
        /// </summary>
        public virtual Dictionary<string, DotHtmlAttribute> Attributes { get; }

        /// <summary>
        ///     Converts the element to HTML.
        /// </summary>
        public override DotHtml ToHtml()
        {
            var result = new StringBuilder();

            var attrs = Attributes.Select(attr =>
                $"{attr.Key}=\"{attr.Value.ToHtml()}\"");

            var tagWithAttributes = string.Join(
                " ",
                Enumerable.Empty<string>().Append($"<{_name}").Concat(attrs)
            );
            result.Append(tagWithAttributes);

            if (_contentAllowed)
            {
                result.Append(">");
                AppendChildren(result);
                result.Append($"</{_name}>");
            }
            else
            {
                result.Append(" />");
            }

            return result.ToString();
        }

        protected virtual void AppendChildren(StringBuilder output)
        {
        }
    }
}