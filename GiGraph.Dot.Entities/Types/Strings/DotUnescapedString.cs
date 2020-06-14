using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Strings
{
    public class DotUnescapedString : DotString
    {
        protected readonly IDotTextEscaper _valueEscaper;

        protected DotUnescapedString(string value, IDotTextEscaper valueEscaper)
            : base(value)
        {
            _valueEscaper = valueEscaper;
        }

        public DotUnescapedString(string value)
            : this(value, TextEscapingPipeline.ForString())
        {
        }

        public virtual DotEscapedString Escape()
        {
            return _valueEscaper.Escape(_value);
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options)
        {
            return Escape();
        }

        public static implicit operator DotUnescapedString(string value)
        {
            return value is {} ? new DotUnescapedString(value) : null;
        }
    }
}