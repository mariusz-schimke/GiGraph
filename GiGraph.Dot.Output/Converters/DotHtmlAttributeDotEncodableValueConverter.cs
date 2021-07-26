using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Converters
{
    public class DotHtmlAttributeDotEncodableValueConverter : IDotValueConverter
    {
        public bool CanConvert(Type type)
        {
            return typeof(IDotEncodable).IsAssignableFrom(type);
        }

        public string Convert(object value, DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return ((IDotEncodable) value).GetDotEncodedValue(options, syntaxRules);
        }
    }
}