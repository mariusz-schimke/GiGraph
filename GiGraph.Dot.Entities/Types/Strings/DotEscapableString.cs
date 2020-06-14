using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Strings
{
    public class DotEscapableString : DotString
    {
        protected readonly IDotTextEscaper _valueEscaper;

        protected DotEscapableString(string value, IDotTextEscaper valueEscaper)
            : base(value)
        {
            _valueEscaper = valueEscaper;
        }

        public DotEscapableString(string value)
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

        public static implicit operator DotEscapableString(string value)
        {
            return value is {} ? new DotEscapableString(value) : null;
        }
    }
}