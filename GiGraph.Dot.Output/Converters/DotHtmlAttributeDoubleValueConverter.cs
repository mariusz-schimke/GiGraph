using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Converters
{
    public class DotHtmlAttributeDoubleValueConverter : IDotValueConverter
    {
        public bool CanConvert(Type type)
        {
            return typeof(double).IsAssignableFrom(type);
        }

        public string Convert(object value, DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return ((double) value).ToString(syntaxRules.Culture);
        }
    }
}