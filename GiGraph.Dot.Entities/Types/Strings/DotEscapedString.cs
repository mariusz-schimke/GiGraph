using System;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Strings
{
    /// <summary>
    ///     An escaped string to be rendered as is on output DOT script generation. It should follow the formatting rules described in
    ///     the
    ///     <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString">
    ///         documentation
    ///     </see>
    ///     .
    /// </summary>
    public class DotEscapedString : DotEscapeString
    {
        protected readonly string _value;

        protected DotEscapedString(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value), "Value must not be null.");
        }

        protected internal override string GetRawString()
        {
            return _value;
        }

        protected internal override string GetEscapedString(IDotTextEscaper textEscaper)
        {
            return _value;
        }

        public static implicit operator DotEscapedString(string value)
        {
            return value is {} ? new DotEscapedString(value) : null;
        }
    }
}