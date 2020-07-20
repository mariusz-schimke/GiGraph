using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Strings
{
    /// <summary>
    ///     A string of a record node field that will be escaped on output DOT script generation.
    /// </summary>
    public class DotUnescapedRecordFieldString : DotUnescapedString
    {
        protected DotUnescapedRecordFieldString(string value)
            : base(value)
        {
        }

        protected internal override string GetDotEncodedString(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return syntaxRules.EscapeRecordField(_value);
        }

        /// <summary>
        ///     Creates a new instance initialized with escaped string. The string will not be modified in any way on output DOT script
        ///     generation, so it should follow the node record field formatting rules described in the
        ///     <see href="http://www.graphviz.org/doc/info/shapes.html#record">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        /// <param name="value">
        ///     The string to use.
        /// </param>
        public new static DotEscapedString FromEscapedString(string value)
        {
            return DotEscapedString.FromEscapedString(value);
        }

        public static implicit operator DotUnescapedRecordFieldString(string value)
        {
            return value is {} ? new DotUnescapedRecordFieldString(value) : null;
        }
    }
}