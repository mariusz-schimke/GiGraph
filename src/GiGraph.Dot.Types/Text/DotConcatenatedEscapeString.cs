using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Types.Text
{
    /// <summary>
    ///     Represents a collection of escape string instances.
    /// </summary>
    public class DotConcatenatedEscapeString : DotEscapeString, IEnumerable<DotEscapeString>
    {
        protected readonly DotEscapeString[] _items;

        /// <summary>
        ///     Creates a new concatenated escape string instance.
        /// </summary>
        /// <param name="items">
        ///     The escape strings to initialize the instance with.
        /// </param>
        public DotConcatenatedEscapeString(params DotEscapeString[] items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items), "Escape string collection must not be null.");
            }

            // flatten to prevent multiple recursion on building the output string
            _items = items.SelectMany
                (
                    item => item is IEnumerable<DotEscapeString> concatenated
                        ? concatenated
                        : Enumerable.Empty<DotEscapeString>().Append(item)
                )
               .ToArray();
        }

        /// <summary>
        ///     Creates a new concatenated escape string instance.
        /// </summary>
        /// <param name="items">
        ///     The escape strings to initialize the instance with.
        /// </param>
        public DotConcatenatedEscapeString(IEnumerable<DotEscapeString> items)
            : this(items?.ToArray())
        {
        }

        /// <summary>
        ///     Creates a new concatenated escape string instance.
        /// </summary>
        /// <param name="items">
        ///     The escape strings to initialize the instance with.
        /// </param>
        public DotConcatenatedEscapeString(IEnumerable<string> items)
            : this(items?.Select(item => (DotEscapeString) item))
        {
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<DotEscapeString> GetEnumerator()
        {
            return ((IEnumerable<DotEscapeString>) _items).GetEnumerator();
        }

        /// <summary>
        ///     Returns an enumerator that iterates through a collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        protected internal override string GetRawString()
        {
            return string.Join(string.Empty, _items.Select(item => item?.GetRawString()));
        }

        protected internal override string GetEscapedString(IDotTextEscaper textEscaper)
        {
            return string.Join(string.Empty, _items.Select(item => item?.GetEscapedString(textEscaper)));
        }
    }
}