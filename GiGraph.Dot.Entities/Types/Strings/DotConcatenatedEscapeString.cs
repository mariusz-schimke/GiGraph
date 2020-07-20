using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Strings
{
    /// <summary>
    ///     Represents a collection of escape string instances.
    /// </summary>
    public class DotConcatenatedEscapeString : DotEscapeString
    {
        protected readonly IEnumerable<DotEscapeString> _items;

        protected internal DotConcatenatedEscapeString(IEnumerable<DotEscapeString> items)
        {
            _items = items;
        }

        protected internal override string GetRawString()
        {
            return string.Join(string.Empty, _items.Select(item => item.GetRawString()));
        }

        protected internal override string GetDotEncodedString(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return string.Join(string.Empty, _items.Select(item => item.GetDotEncodedString(options, syntaxRules)));
        }

        public static implicit operator DotConcatenatedEscapeString(DotEscapeString[] value)
        {
            return value is {} ? new DotConcatenatedEscapeString(value) : null;
        }
    }
}