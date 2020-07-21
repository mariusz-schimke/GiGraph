using System;
using System.Linq;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Strings
{
    /// <summary>
    ///     Represents a collection of escape string instances.
    /// </summary>
    public class DotConcatenatedEscapeString : DotEscapeString
    {
        protected readonly DotEscapeString[] _items;

        protected internal DotConcatenatedEscapeString(DotEscapeString[] items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items), "Escape string collection cannot be null.");
        }

        protected internal override string GetRawString()
        {
            return string.Join(string.Empty, _items.Select(item => item?.GetRawString()));
        }

        protected internal override string GetDotEncodedString(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return string.Join(string.Empty, _items.Select(item => item?.GetDotEncodedString(options, syntaxRules)));
        }

        public static implicit operator DotConcatenatedEscapeString(DotEscapeString[] value)
        {
            return value is {} ? new DotConcatenatedEscapeString(value) : null;
        }

        public static implicit operator DotEscapeString[](DotConcatenatedEscapeString value)
        {
            return value?._items?.ToArray();
        }

        public static DotConcatenatedEscapeString operator +(DotConcatenatedEscapeString value1, DotEscapeString value2)
        {
            var result = Enumerable.Empty<DotEscapeString>();

            if (value1 is {})
            {
                // flatten to prevent recursion on building the output string
                result = result.Concat(value1._items);
            }

            return result.Append(value2).ToArray();
        }

        public static DotConcatenatedEscapeString operator +(DotEscapeString value1, DotConcatenatedEscapeString value2)
        {
            var result = Enumerable.Empty<DotEscapeString>().Append(value1);

            if (value2 is {})
            {
                // flatten to prevent recursion on building the output string
                result = result.Concat(value2._items);
            }

            return result.ToArray();
        }
    }
}