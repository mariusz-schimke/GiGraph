using System;
using GiGraph.Dot.Output.Text.Escaping;

namespace GiGraph.Dot.Types.Text
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

        /// <summary>
        ///     Initializes a new instance.
        /// </summary>
        /// <param name="value">
        ///     The escaped string to initialize the instance with.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <paramref name="value" /> is null.
        /// </exception>
        public DotEscapedString(string value)
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
            return value is not null ? new DotEscapedString(value) : null;
        }
    }
}