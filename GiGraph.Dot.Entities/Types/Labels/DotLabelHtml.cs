using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Types.Labels
{
    public class DotLabelHtml : DotLabelString
    {
        protected DotLabelHtml(string value)
            : base((DotEscapedString) value)
        {
        }

        public static implicit operator DotLabelHtml(string value)
        {
            return value is {} ? new DotLabelHtml(value) : null;
        }
    }
}