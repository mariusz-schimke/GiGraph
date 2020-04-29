using System.Web;

namespace Dotless.Generators.AttributeGenerators
{
    public class DotAttributeGeneratorOptions
    {
        /// <summary>
        /// When set, attribute value will always be quoted, even if that is not required.
        /// </summary>
        public bool PreferQuotedValue { get; set; } = true;

        /// <summary>
        /// When set, <see cref="HttpUtility.HtmlEncode"/> is used for text label attribute escaping.
        /// </summary>
        public bool HtmlEscapeText { get; set; } = true;
    }
}
