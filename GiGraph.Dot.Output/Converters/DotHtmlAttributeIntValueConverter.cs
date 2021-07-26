using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Converters
{
    public class DotHtmlAttributeIntValueConverter : IDotValueConverter
    {
        public bool CanConvert(Type type)
        {
            return typeof(int).IsAssignableFrom(type);
        }

        public string Convert(object value, DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return ((int) value).ToString(syntaxRules.Culture);
        }
    }
}