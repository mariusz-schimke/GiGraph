using System;
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
    }
}