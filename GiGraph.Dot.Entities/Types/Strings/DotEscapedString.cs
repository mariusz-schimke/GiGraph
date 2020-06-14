using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Strings
{
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