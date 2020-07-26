using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Strings
{
    /// <summary>
    ///     Represents the DOT escape string (<see href="http://www.graphviz.org/doc/info/attrs.html#k:escString" />).
    /// </summary>
    public abstract class DotEscapeString : IDotEscapable
    {
        /// <summary>
        ///     An escape sequence replaced with graph identifier on graph visualization.
        /// </summary>
        public static DotEscapeString GraphId => (DotEscapedString) "\\G";

        /// <summary>
        ///     An escape sequence replaced with the identifier of the current node on graph visualization.
        /// </summary>
        public static DotEscapeString NodeId => (DotEscapedString) "\\N";

        /// <summary>
        ///     An escape sequence replaced with the definition of the current edge on graph visualization.
        /// </summary>
        public static DotEscapeString EdgeDefinition => (DotEscapedString) "\\E";

        /// <summary>
        ///     An escape sequence replaced with the identifier of the tail node of the current edge on graph visualization.
        /// </summary>
        public static DotEscapeString EdgeTailNodeId => (DotEscapedString) "\\T";

        /// <summary>
        ///     An escape sequence replaced with the identifier of the head node of the current edge on graph visualization.
        /// </summary>
        public static DotEscapeString EdgeHeadNodeId => (DotEscapedString) "\\H";

        /// <summary>
        ///     An escape sequence replaced with the label of the current element on graph visualization.
        /// </summary>
        public static DotEscapeString Label => (DotEscapedString) "\\L";

        /// <summary>
        ///     An escape sequence interpreted as a line break.
        /// </summary>
        public static DotEscapeString LineBreak => (DotEscapedString) "\\n";

        /// <summary>
        ///     An escape sequence that causes the line of text that precedes it to be left-justified.
        /// </summary>
        public static DotEscapeString LeftJustification => (DotEscapedString) "\\l";

        /// <summary>
        ///     An escape sequence that causes the line of text that precedes it to be right-justified.
        /// </summary>
        public static DotEscapeString RightJustification => (DotEscapedString) "\\r";

        string IDotEscapable.GetEscaped(IDotTextEscaper textEscaper)
        {
            return GetEscapedString(textEscaper);
        }

        /// <summary>
        ///     Returns left-justified text.
        /// </summary>
        /// <param name="text">
        ///     The text to justify.
        /// </param>
        public static DotEscapeString JustifyLeft(string text)
        {
            return text + LeftJustification;
        }

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
        public static DotEscapeString JustifyRight(string text)
        {
            return text + RightJustification;
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

        protected internal abstract string GetRawString();
        protected internal abstract string GetEscapedString(IDotTextEscaper textEscaper);

        public override string ToString()
        {
            return GetRawString();
        }

        /// <summary>
        ///     Creates a new instance initialized with the specified text. The text will be escaped on output DOT script generation.
        /// </summary>
        /// <param name="value">
        ///     The string to use.
        /// </param>
        public static DotEscapeString FromString(string value)
        {
            return (DotUnescapedString) value;
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
            return (DotEscapedString) value;
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
        public static DotEscapeString ConcatEscaped(params string[] items)
        {
            return ConcatEscaped((IEnumerable<string>) items);
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
        public static DotEscapeString ConcatEscaped(IEnumerable<string> items)
        {
            return new DotConcatenatedEscapeString(items?.Select(FromEscapedString));
        }

        public static implicit operator DotEscapeString(string value)
        {
            return (DotUnescapedString) value;
        }

        public static implicit operator string(DotEscapeString value)
        {
            return value?.GetRawString();
        }

        public static DotEscapeString operator +(DotEscapeString value1, DotEscapeString value2)
        {
            return new DotConcatenatedEscapeString(value1, value2);
        }
    }
}