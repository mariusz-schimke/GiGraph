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
            return syntaxRules.Attributes.Html.AttributeStringValueEscaper.Escape((string) value);
        }
    }
}