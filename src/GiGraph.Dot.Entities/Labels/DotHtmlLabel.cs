using System;
using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Html;

namespace GiGraph.Dot.Entities.Labels
{
    /// <summary>
    ///     Represents an HTML label with an underlying object capable of being converted to HTML on DOT output rendering.
    /// </summary>
    public class DotHtmlLabel : DotLabel
    {
        protected readonly IDotHtmlEncodable _value;

        /// <summary>
        ///     Creates a new label instance.
        /// </summary>
        /// <param name="htmlEntity">
        ///     The object capable of being converted to HTML.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="htmlEntity" /> is null.
        /// </exception>
        public DotHtmlLabel(IDotHtmlEntity htmlEntity)
        {
            _value = htmlEntity ?? throw new ArgumentNullException(nameof(htmlEntity), "HTML entity must not be null.");
        }

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
        public DotHtmlLabel(DotHtmlString html)
        {
            _value = html ?? throw new ArgumentNullException(nameof(html), "HTML string must not be null.");
        }

        protected internal override string GetDotEncodedString(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return _value.ToHtml(options, syntaxRules);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public static implicit operator DotHtmlLabel(DotHtmlEntity htmlEntity)
        {
            return htmlEntity is not null ? new DotHtmlLabel(htmlEntity) : null;
        }

        public static implicit operator DotHtmlLabel(DotHtmlEntityCollection htmlEntityCollection)
        {
            return htmlEntityCollection is not null ? new DotHtmlLabel(htmlEntityCollection) : null;
        }

        public static implicit operator DotHtmlLabel(string html)
        {
            return html is not null ? new DotHtmlLabel(html) : null;
        }

        public static implicit operator DotHtmlLabel(DotHtmlString html)
        {
            return html is not null ? new DotHtmlLabel(html) : null;
        }

        public static implicit operator string(DotHtmlLabel label)
        {
            return label?.ToString();
        }

        public static implicit operator DotHtmlString(DotHtmlLabel label)
        {
            return label?.ToString();
        }
    }
}