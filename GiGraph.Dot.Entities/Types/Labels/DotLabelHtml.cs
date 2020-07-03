using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Types.Labels
{
    /// <summary>
    ///     Represents an HTML-like label. The value is a compatible HTML string following the rules described in the
    ///     <see href="http://www.graphviz.org/doc/info/shapes.html#html">
    ///         documentation
    ///     </see>
    ///     .
    /// </summary>
    public class DotLabelHtml : DotLabelString
    {
        protected DotLabelHtml(string html)
            : base((DotEscapedString) html)
        {
        }

        public static implicit operator DotLabelHtml(string html)
        {
            return html is {} ? new DotLabelHtml(html) : null;
        }
    }
}