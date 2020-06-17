using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Strings
{
    /// <summary>
    /// A string of a record node field that will be escaped on output DOT script generation.
    /// </summary>
    public class DotEscapableRecordFieldString : DotEscapableString
    {
        protected DotEscapableRecordFieldString(string value, IDotTextEscaper valueEscaper)
            : base(value, valueEscaper)
        {
        }

        protected DotEscapableRecordFieldString(string value)
            : this(value, DotTextEscapingPipeline.ForRecordNodeField())
        {
        }

        /// <summary>
        /// Creates a new instance initialized with escaped string. The string will not be modified in any way
        /// on output DOT script generation, so it should follow the node record field formatting rules
        /// described in the documentation available at <see href="http://www.graphviz.org/doc/info/shapes.html#record"/>.
        /// </summary>
        /// <param name="value">The string to use.</param>
        public new static DotEscapedString FromEscapedString(string value)
        {
            return DotEscapedString.FromEscapedString(value);
        }

        public static implicit operator DotEscapableRecordFieldString(string value)
        {
            return value is {} ? new DotEscapableRecordFieldString(value) : null;
        }
    }
}