using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Types.Labels
{
    public class DotLabelString
    {
        protected readonly DotString _text;

        public DotLabelString(string text)
        {
            _text = (DotUnescapedString) text;
        }

        public DotLabelString(DotString text)
        {
            _text = text;
        }

        public static implicit operator DotLabelString(string value)
        {
            return value is {} ? new DotLabelString(value) : null;
        }

        public static implicit operator DotLabelString(DotString value)
        {
            return value is {} ? new DotLabelString(value) : null;
        }

        public static implicit operator string(DotLabelString labelString)
        {
            return labelString?._text;
        }

        public static implicit operator DotString(DotLabelString labelString)
        {
            return labelString?._text;
        }
    }
}