using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Strings
{
    /// <summary>
    ///     Represents the DOT escape string (<see href="http://www.graphviz.org/doc/info/attrs.html#k:escString" />).
    /// </summary>
    public abstract class DotEscapeString : IDotEncodable
    {
        /// <summary>
        ///     An escape sequence replaced with graph identifier on graph visualization.
        /// </summary>
        public static DotEscapeString GraphId => (DotEscapedString)"\\G";

        /// <summary>
        ///     An escape sequence replaced with the identifier of the current node on graph visualization.
        /// </summary>
        public static DotEscapeString NodeId => (DotEscapedString)"\\N";

        /// <summary>
        ///     An escape sequence replaced with the definition of the current edge on graph visualization.
        /// </summary>
        public static DotEscapeString EdgeDefinition => (DotEscapedString)"\\E";

        /// <summary>
        ///     An escape sequence replaced with the identifier of the tail node of the current edge on graph visualization.
        /// </summary>
        public static DotEscapeString EdgeTailNodeId => (DotEscapedString)"\\T";

        /// <summary>
        ///     An escape sequence replaced with the identifier of the head node of the current edge on graph visualization.
        /// </summary>
        public static DotEscapeString EdgeHeadNodeId => (DotEscapedString)"\\H";

        /// <summary>
        ///     An escape sequence replaced with the label of the current element on graph visualization.
        /// </summary>
        public static DotEscapeString Label => (DotEscapedString)"\\L";

        /// <summary>
        ///     An escape sequence interpreted as a line break.
        /// </summary>
        public static DotEscapeString NewLine => (DotEscapedString)"\\n";

        /// <summary>
        ///     An escape sequence that causes the line of text that precedes it to be left-justified.
        /// </summary>
        public static DotEscapeString JustifyLeft => (DotEscapedString)"\\l";

        /// <summary>
        ///     An escape sequence that causes the line of text that precedes it to be right-justified.
        /// </summary>
        public static DotEscapeString JustifyRight => (DotEscapedString)"\\r";

        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedString(options, syntaxRules);
        }

        protected internal abstract string GetRawString();
        protected internal abstract string GetDotEncodedString(DotGenerationOptions options, DotSyntaxRules syntaxRules);

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
        public static DotUnescapedString FromString(string value)
        {
            return value;
        }

        /// <summary>
        ///     Creates a new instance initialized with escaped string. The string will not be modified in any way on output DOT script
        ///     generation, so it should follow the formatting rules described in the
        ///     <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        /// <param name="value">
        ///     The string to use.
        /// </param>
        public static DotEscapedString FromEscapedString(string value)
        {
            return value;
        }

        public static implicit operator DotEscapeString(string value)
        {
            return (DotUnescapedString) value;
        }

        public static implicit operator string(DotEscapeString value)
        {
            return value?.GetRawString();
        }

        public static DotConcatenatedEscapeString operator +(DotEscapeString value1, DotEscapeString value2)
        {
            return new[] { value1, value2 };
        }
    }
}