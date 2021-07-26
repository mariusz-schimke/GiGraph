using System;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Converters
{
    public class DotHtmlAttributeEnumValueConverter : IDotValueConverter
    {
        public bool CanConvert(Type type)
        {
            return typeof(Enum).IsAssignableFrom(type);
        }

        public string Convert(object value, DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return DotHtmlElementAttributeValue.TryGet((Enum) value, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(value), $"The specified HTML attribute enumeration value '{value}' is invalid.");
        }
    }
}