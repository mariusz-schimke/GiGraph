using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Html.Attributes
{
    /// <summary>
    ///     A string attribute whose value is escaped on DOT script rendering when <see cref="DotUnescapedString" /> is used, or is
    ///     assumed to already be escaped when <see cref="DotEscapedString" /> is used. For use in the context of HTML elements
    /// </summary>
    public class DotHtmlEscapeStringAttribute : DotEscapeStringAttribute
    {
        /// <summary>
        ///     Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotHtmlEscapeStringAttribute(string key, DotEscapeString value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return ((IDotEscapable) Value)?.GetEscaped(syntaxRules.Attributes.Html.AttributeEscapeStringValueEscaper);
        }
    }
}