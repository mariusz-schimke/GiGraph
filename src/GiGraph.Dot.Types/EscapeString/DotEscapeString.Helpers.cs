using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Types.EscapeString
{
    public abstract partial class DotEscapeString
    {
        /// <summary>
        ///     Returns left-justified text.
        /// </summary>
        /// <param name="text">
        ///     The text to justify.
        /// </param>
        public static DotEscapeString JustifyLeft(DotEscapeString text)
        {
            return text + LeftJustification;
        }

        /// <summary>
        ///     Returns right-justified text.
        /// </summary>
        /// <param name="text">
        ///     The text to justify.
        /// </param>
        public static DotEscapeString JustifyRight(DotEscapeString text)
        {
            return text + RightJustification;
        }

        /// <summary>
        ///     Creates a new instance initialized with the specified text. The text will be escaped on output DOT script generation.
        /// </summary>
        /// <param name="value">
        ///     The string to use.
        /// </param>
        public static DotEscapeString FromString(string value)
        {
            return new DotUnescapedString(value);
        }

        /// <summary>
        ///     Creates a new instance initialized with escaped string. The string will not be modified in any way on output DOT script
        ///     generation, so it must follow the formatting rules described in the
        ///     <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        /// <param name="value">
        ///     The string to use.
        /// </param>
        public static DotEscapeString FromEscapedString(string value)
        {
            return new DotEscapedString(value);
        }

        /// <summary>
        ///     Concatenates the specified escape strings.
        /// </summary>
        /// <param name="items">
        ///     The escape string items to concatenate.
        /// </param>
        public static DotEscapeString Concat(params DotEscapeString[] items)
        {
            return new DotConcatenatedEscapeString(items);
        }

        /// <summary>
        ///     Concatenates the specified escape strings.
        /// </summary>
        /// <param name="items">
        ///     The escape string items to concatenate.
        /// </param>
        public static DotEscapeString Concat(IEnumerable<DotEscapeString> items)
        {
            return new DotConcatenatedEscapeString(items);
        }

        /// <summary>
        ///     Concatenates the specified escape strings.
        /// </summary>
        /// <param name="items">
        ///     The escape string items to concatenate.
        /// </param>
        public static DotEscapeString Concat(params string[] items)
        {
            return new DotConcatenatedEscapeString(items);
        }

        /// <summary>
        ///     Concatenates the specified escape strings.
        /// </summary>
        /// <param name="items">
        ///     The escape string items to concatenate.
        /// </param>
        public static DotEscapeString Concat(IEnumerable<string> items)
        {
            return new DotConcatenatedEscapeString(items);
        }

        /// <summary>
        ///     Concatenates the specified escaped strings. The component strings will not be modified in any way on output DOT script
        ///     generation, so they must follow the formatting rules described in the
        ///     <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        /// <param name="items">
        ///     The string to use.
        /// </param>
        public static DotEscapeString ConcatEscapedStrings(params string[] items)
        {
            return ConcatEscapedStrings((IEnumerable<string>) items);
        }

        /// <summary>
        ///     Concatenates the specified escaped strings. The component strings will not be modified in any way on output DOT script
        ///     generation, so they must follow the formatting rules described in the
        ///     <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        /// <param name="items">
        ///     The string to use.
        /// </param>
        public static DotEscapeString ConcatEscapedStrings(IEnumerable<string> items)
        {
            return new DotConcatenatedEscapeString(items?.Select(FromEscapedString));
        }
    }
}