using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Labels
{
    public class DotLabelString : IDotEncodableValue
    {
        protected readonly DotEscapableString _text;

        protected DotLabelString(string text)
        {
            _text = text;
        }

        protected DotLabelString(DotEscapableString text)
        {
            _text = text;
        }

        protected DotLabelString(DotEscapedString text)
        {
            _text = text;
        }

        protected internal string GetDotEncodedString(DotGenerationOptions options)
        {
            return _text?.GetDotEncodedString(options);
        }

        string IDotEncodableValue.GetDotEncodedValue(DotGenerationOptions options) => GetDotEncodedString(options);

        public static implicit operator DotLabelString(string value)
        {
            return value is {} ? new DotLabelString(value) : null;
        }

        public static implicit operator DotLabelString(DotEscapableString value)
        {
            return value is {} ? new DotLabelString(value) : null;
        }

        public static implicit operator DotLabelString(DotEscapedString value)
        {
            return value is {} ? new DotLabelString(value) : null;
        }

        public static implicit operator string(DotLabelString labelString)
        {
            return labelString?._text;
        }

        public static implicit operator DotEscapableString(DotLabelString labelString)
        {
            return labelString?._text;
        }
    }
}