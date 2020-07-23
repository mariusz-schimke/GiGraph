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
    public class DotHtmlLabel : DotTextLabel
    {
        protected DotHtmlLabel(string html)
            : base((DotEscapedString) html)
        {
        }

        public static implicit operator DotHtmlLabel(string html)
        {
            return html is {} ? new DotHtmlLabel(html) : null;
        }
    }
}