using System;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Text
{
    /// <summary>
    ///     Represents an HTML string. The value should be a compatible HTML string following the rules described in the
    ///     <see href="http://www.graphviz.org/doc/info/shapes.html#html">
    ///         documentation
    ///     </see>
    ///     .
    /// </summary>
    public class DotHtmlString : IDotHtmlEncodable
    {
        protected readonly string _html;

        /// <summary>
        ///     Initializes a new instance.
        /// </summary>
        /// <param name="html">
        ///     The HTML string to initialize the instance with.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the <paramref name="html" /> is null.
        /// </exception>
        public DotHtmlString(string html)
        {
            _html = html ?? throw new ArgumentNullException(nameof(html), "HTML string must not be null.");
        }

        string IDotHtmlEncodable.ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return _html;
        }

        public override string ToString()
        {
            return _html;
        }

        public static implicit operator DotHtmlString(string value)
        {
            return value is not null ? new DotHtmlString(value) : null;
        }

        public static implicit operator string(DotHtmlString value)
        {
            return value?._html;
        }

        public static implicit operator DotUnescapedString(DotHtmlString value)
        {
            return value?._html;
        }

        public static DotHtmlString operator +(DotHtmlString value1, DotHtmlString value2)
        {
            return $"{value1?._html}{value2?._html}";
        }
    }
}