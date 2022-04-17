using System.Collections.Generic;
using System.Linq;
using System.Text;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Text;

namespace GiGraph.Dot.Entities.Html;

/// <summary>
///     Represents an HTML tag with optional attributes.
/// </summary>
public abstract class DotHtmlTag : DotHtmlEntity
{
    protected readonly string _name;

    protected DotHtmlTag(string name, DotHtmlAttributeCollection attributes)
    {
        _name = name;
        Attributes = attributes;
    }

    /// <summary>
    ///     Gets the collection of attributes of the element.
    /// </summary>
    public DotHtmlAttributeCollection Attributes { get; }

    protected abstract bool IsVoid { get; }

    protected internal override string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        var result = new StringBuilder();

        var attrs = Attributes.Values
           .Select(attr =>
                $"{DotTextCasing.SetCasing(attr.Key, options.Attributes.Html.AttributeKeyCasing)}=\"{attr.GetDotEncodedValue(options, syntaxRules)}\""
            );

        var elementName = DotTextCasing.SetCasing(_name, options.Attributes.Html.ElementNameCasing);
        var elementWithAttributes = string.Join(
            " ",
            Enumerable.Empty<string>()
               .Append($"<{elementName}")
               .Concat(attrs)
        );

        result.Append(elementWithAttributes);

        if (IsVoid)
        {
            result.Append("/>");
        }
        else
        {
            result.Append(">");

            var children = GetContent().Select(child => child.ToHtml(options, syntaxRules));
            result.Append(string.Join(string.Empty, children));

            result.Append($"</{elementName}>");
        }

        return result.ToString();
    }

    protected virtual IEnumerable<IDotHtmlEntity> GetContent()
    {
        return Enumerable.Empty<IDotHtmlEntity>();
    }
}