using System;
using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Labels
{
    /// <summary>
    ///     Represents an HTML label with an underlying object capable of being converted to HTML on DOT output rendering.
    /// </summary>
    public class DotHtmlLabel : DotLabel
    {
        protected readonly IDotHtmlEncodable _htmlEntity;

        /// <summary>
        ///     Creates a new label instance.
        /// </summary>
        /// <param name="htmlEntity">
        ///     The object capable of being converted to HTML.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="htmlEntity" /> is null.
        /// </exception>
        public DotHtmlLabel(IDotHtmlEncodable htmlEntity)
        {
            _htmlEntity = htmlEntity ?? throw new ArgumentNullException(nameof(htmlEntity), "HTML entity must not be null.");
        }

        protected internal override string GetDotEncodedString(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return _htmlEntity?.ToHtml(options, syntaxRules);
        }

        public override string ToString()
        {
            return _htmlEntity?.ToString();
        }

        public static implicit operator DotHtmlLabel(DotHtmlEntity htmlEntity)
        {
            return htmlEntity is not null ? new DotHtmlLabel(htmlEntity) : null;
        }

        public static implicit operator DotHtmlLabel(DotHtmlEntityCollection htmlEntityCollection)
        {
            return htmlEntityCollection is not null ? new DotHtmlLabel(htmlEntityCollection) : null;
        }
    }
}