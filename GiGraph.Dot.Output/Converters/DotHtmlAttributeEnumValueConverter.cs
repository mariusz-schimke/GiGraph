using System;
using GiGraph.Dot.Output.Metadata.Html;
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
                : throw new ArgumentOutOfRangeException(nameof(value), $"The specified value '{value}' of the '{value.GetType().Name}' enumeration is invalid or is not mapped to any HTML attribute value.");
        }
    }
}