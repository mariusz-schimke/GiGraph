using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Strings
{
    /// <summary>
    /// A string that will be escaped on output DOT script generation.
    /// </summary>
    public class DotEscapableString : IDotEncodable
    {
        protected readonly string _value;

        protected DotEscapableString(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value), "Value cannot be null.");
        }

        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedString(options, syntaxRules);
        }

        public override string ToString()
        {
            return _value;
        }

        protected internal virtual string GetDotEncodedString(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return syntaxRules.EscapeStringValue(_value);
        }

        /// <summary>
        /// Creates a new instance initialized with the specified text. The text will be escaped on output DOT script generation
        /// so that it can be parsed and visualized correctly.
        /// </summary>
        /// <param name="value">The string to use.</param>
        public static DotEscapableString FromString(string value)
        {
            return value;
        }

        /// <summary>
        /// Creates a new instance initialized with escaped string. The string will not be modified in any way
        /// on output DOT script generation, so it should follow the formatting rules described in the
        /// <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString">documentation</see>.
        /// </summary>
        /// <param name="value">The string to use.</param>
        public static DotEscapedString FromEscapedString(string value)
        {
            return value;
        }

        public static implicit operator DotEscapableString(string value)
        {
            return value is {} ? new DotEscapableString(value) : null;
        }

        public static implicit operator string(DotEscapableString value)
        {
            return value?._value;
        }
    }
}