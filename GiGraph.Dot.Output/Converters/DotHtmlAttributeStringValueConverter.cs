using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Converters
{
    public class DotHtmlAttributeStringValueConverter : IDotValueConverter
    {
        public bool CanConvert(Type type)
        {
            return typeof(string).IsAssignableFrom(type);
        }

        public string Convert(object value, DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            // TODO: consider tabs and non-braking spaces?
            // https://graphviz.org/doc/info/shapes.html#html
            // "All non-printing characters such as tabs or newlines are ignored."
            return syntaxRules.Attributes.Html.AttributeStringValueEscaper.Escape((string) value);
        }
    }
}