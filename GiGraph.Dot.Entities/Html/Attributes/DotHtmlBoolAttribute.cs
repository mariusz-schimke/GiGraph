using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Html.Attributes
{
    /// <summary>
    ///     A boolean value attribute for use in the context of HTML elements.
    /// </summary>
    public class DotHtmlBoolAttribute : DotBoolAttribute
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
        public DotHtmlBoolAttribute(string key, bool value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Value ? "TRUE" : "FALSE";
        }
    }
}