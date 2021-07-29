using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Output.Options
{
    public partial class DotSyntaxRules
    {
        public class HtmlRules
        {
            /// <summary>
            ///     A text escaper to use for HTML attribute values of the string type.
            /// </summary>
            public virtual IDotTextEscaper AttributeStringValueEscaper { get; set; } = DotTextEscapingPipeline.ForHtmlAttributeStringValue();

            /// <summary>
            ///     A text escaper to use for HTML attribute values of the escape string type.
            /// </summary>
            public virtual IDotTextEscaper AttributeEscapeStringValueEscaper { get; set; } = DotTextEscapingPipeline.ForHtmlAttributeEscapeStringValue();

            /// <summary>
            ///     A text escaper to use for textual content of HTML elements.
            /// </summary>
            public virtual IDotTextEscaper ElementTextContentEscaper { get; set; } = DotTextEscapingPipeline.ForHtmlElementTextContent();
        }
    }
}