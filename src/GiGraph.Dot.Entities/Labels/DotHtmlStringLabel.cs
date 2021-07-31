using System;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Labels
{
    /// <summary>
    ///     Represents an HTML string label. The value should be a compatible HTML string following the rules described in the
    ///     <see href="http://www.graphviz.org/doc/info/shapes.html#html">
    ///         documentation
    ///     </see>
    ///     .
    /// </summary>
    public class DotHtmlStringLabel : DotLabel
    {
        protected readonly DotHtmlString _html;

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
        {
            _html = html ?? throw new ArgumentNullException(nameof(html), "HTML string must not be null.");
        }

        public override string ToString()
        {
            return _html;
        }

        protected internal override string GetDotEncodedString(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => _html;

        public static implicit operator DotHtmlStringLabel(string html)
        {
            return html is not null ? new DotHtmlStringLabel(html) : null;
        }

        public static implicit operator DotHtmlStringLabel(DotHtmlString html)
        {
            return html is not null ? new DotHtmlStringLabel(html) : null;
        }

        public static implicit operator string(DotHtmlStringLabel label)
        {
            return label?._html;
        }

        public static implicit operator DotHtmlString(DotHtmlStringLabel label)
        {
            return label?._html;
        }
    }
}