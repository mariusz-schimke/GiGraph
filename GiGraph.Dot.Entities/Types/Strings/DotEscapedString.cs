using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Strings
{
    /// <summary>
    /// An escaped string that will be rendered as is on output DOT script generation.
    /// It should follow the rules described in the documentation available at
    /// <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString"/>.
    /// </summary>
    public class DotEscapedString : DotEscapableString
    {
        protected DotEscapedString(string value, IDotTextEscaper valueEscaper)
            : base(value, valueEscaper)
        {
        }

        protected DotEscapedString(string value)
            : base(value, TextEscapingPipeline.None())
        {
        }

        public static implicit operator DotEscapedString(string value)
        {
            return value is {} ? new DotEscapedString(value) : null;
        }
    }
}