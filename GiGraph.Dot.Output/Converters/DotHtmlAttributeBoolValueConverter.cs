using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Converters
{
    public class DotHtmlAttributeBoolValueConverter : IDotValueConverter
    {
        public bool CanConvert(Type type)
        {
            return typeof(bool).IsAssignableFrom(type);
        }

        public string Convert(object value, DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return (bool) value ? "TRUE" : "FALSE";
        }
    }
}