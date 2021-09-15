using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Output.Text.Escaping;

namespace GiGraph.Dot.Types.EscapeString
{
    /// <summary>
    ///     Represents the DOT escape string (<see href="http://www.graphviz.org/doc/info/attrs.html#k:escString" />).
    /// </summary>
    public abstract partial class DotEscapeString : IDotEscapable
    {
        string IDotEscapable.GetEscaped(IDotTextEscaper textEscaper)
        {
            return GetEscapedString(textEscaper);
        }

        protected internal abstract string GetRawString();
        protected internal abstract string GetEscapedString(IDotTextEscaper textEscaper);

        /// <summary>
        ///     Returns the underlying string.
        /// </summary>
        public override string ToString()
        {
            return GetRawString();
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