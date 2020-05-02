using System.Web;

namespace Dotless.Writers.Options
{
    public class DotAttributeWriterOptions
    {
        /// <summary>
        /// When set, attribute value will always be quoted, even if that is not required.
        /// </summary>
        public bool PreferQuotedValue { get; set; } = true;

        /// <summary>
        /// When set, <see cref="HttpUtility.HtmlEncode"/> is used for text label attribute escaping.
        /// </summary>
        public bool HtmlEscapeLabelText { get; set; } = true;

        /// <summary>
        /// When set, attributes embedded within a curly-braced block (graph or subhraph body) are separated explicitly with semicolons (;).
        /// On the other hand, attributes enclosed in square brackets (e.g. node attributes), are separated with colons (,).
        /// </summary>
        public bool PreferExplicitDelimiter { get; set; } = true;
    }
}
