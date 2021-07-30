using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Types.Labels
{
    /// <summary>
    ///     Represents an HTML string label. The value should be a compatible HTML string following the rules described in the
    ///     <see href="http://www.graphviz.org/doc/info/shapes.html#html">
    ///         documentation
    ///     </see>
    ///     .
    /// </summary>
    public class DotHtmlStringLabel : DotTextLabel
    {
        /// <summary>
        ///     Creates a new HTML string label.
        /// </summary>
        /// <param name="html">
        ///     The HTML text to use. It is expected to be a compatible HTML string following the rules described in the
        ///     <see href="http://www.graphviz.org/doc/info/shapes.html#html">
        ///         documentation
        ///     </see>
        ///     . Pass <see cref="string" /> to convert it implicitly to the required <see cref="DotHtmlString" /> type.
        /// </param>
        public DotHtmlStringLabel(DotHtmlString html)
            : base(html)
        {
        }

        public static implicit operator DotHtmlStringLabel(string html)
        {
            return html is not null ? new DotHtmlStringLabel(html) : null;
        }

        public static implicit operator DotHtmlStringLabel(DotHtmlString html)
        {
            return html is not null ? new DotHtmlStringLabel(html) : null;
        }
    }
}