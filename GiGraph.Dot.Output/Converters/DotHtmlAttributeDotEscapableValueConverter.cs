using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Converters
{
    public class DotHtmlAttributeDotEscapableValueConverter : IDotValueConverter
    {
        public bool CanConvert(Type type)
        {
            return typeof(IDotEscapable).IsAssignableFrom(type);
        }

        public string Convert(object value, DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return ((IDotEscapable) value).GetEscaped(syntaxRules.Attributes.Html.AttributeEscapeStringValueEscaper);
        }
    }
}