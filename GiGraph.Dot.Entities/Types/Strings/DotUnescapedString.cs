using System;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Strings
{
    /// <summary>
    ///     A string to be escaped on output DOT script generation.
    /// </summary>
    public class DotUnescapedString : DotEscapeString
    {
        protected readonly string _value;

        protected DotUnescapedString(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value), "Value must not be null.");
        }

        protected internal override string GetRawString()
        {
            return _value;
        }

        protected internal override string GetEscapedString(IDotTextEscaper textEscaper)
        {
            return textEscaper.Escape(_value);
        }

        public static implicit operator DotUnescapedString(string value)
        {
            return value is { } ? new DotUnescapedString(value) : null;
        }
    }
}