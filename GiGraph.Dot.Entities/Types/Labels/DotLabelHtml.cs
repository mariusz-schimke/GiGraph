using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Types.Labels
{
    /// <summary>
    /// Represents an HTML-like label. The value is a compatible HTML string following the rules described in the documentation
    /// available at <see href="http://www.graphviz.org/doc/info/shapes.html#html"/>. 
    /// </summary>
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