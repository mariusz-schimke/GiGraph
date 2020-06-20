using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Strings
{
    /// <summary>
    /// An escaped string that will be rendered as is on output DOT script generation.
    /// It should follow the formatting rules described in the documentation available at
    /// <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString"/>.
    /// </summary>
    public class DotEscapedString : DotEscapableString
    {
        protected DotEscapedString(string value)
            : base(value)
        {
        }

        protected internal override string GetDotEncodedString(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return _value;
        }

        public static implicit operator DotEscapedString(string value)
        {
            return value is {} ? new DotEscapedString(value) : null;
        }
    }
}