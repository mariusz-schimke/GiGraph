using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Strings
{
    /// <summary>
    ///     Represents a collection of escape string instances.
    /// </summary>
    public class DotConcatenatedEscapeString : DotEscapeString
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
                throw new ArgumentNullException(nameof(items), "Escape string collection cannot be null.");
            }

            // flatten to prevent multiple recursion on building the output string
            _items = items.SelectMany(item =>
            {
                if (item is DotConcatenatedEscapeString concatenated)
                {
                    return concatenated._items;
                }

                return Enumerable.Empty<DotEscapeString>().Append(item);
            }).ToArray();
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
        ///     Returns the component escape strings of the current instance.
        /// </summary>
        public virtual DotEscapeString[] ToArray()
        {
            return _items.ToArray();
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