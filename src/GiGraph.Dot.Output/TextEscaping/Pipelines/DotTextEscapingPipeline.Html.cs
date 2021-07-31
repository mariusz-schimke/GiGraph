using GiGraph.Dot.Output.TextEscaping.Escapers.Html;

namespace GiGraph.Dot.Output.TextEscaping.Pipelines
{
    public partial class DotTextEscapingPipeline
    {
        /// <summary>
        ///     Creates a new pipeline that escapes HTML text.
        /// </summary>
        public static DotTextEscapingPipeline ForHtmlElementTextContent()
        {
            return new DotTextEscapingPipeline
            (
                new DotHtmlEncodeEscaper()
            );
        }

        /// <summary>
        ///     Creates a new pipeline that escapes HTML comment tag text.
        /// </summary>
        public static DotTextEscapingPipeline ForHtmlCommentText()
        {
            return new DotTextEscapingPipeline
            (
                new DotHtmlEncodeEscaper()
            );
        }

        /// <summary>
        ///     Creates a new pipeline that escapes HTML attribute value of the string type.
        /// </summary>
        public static DotTextEscapingPipeline ForHtmlAttributeStringValue()
        {
            return new DotTextEscapingPipeline
            (
                new DotHtmlEncodeEscaper()
            );
        }

        /// <summary>
        ///     Creates a new pipeline that escapes HTML attribute value of the escape string type.
        /// </summary>
        public static DotTextEscapingPipeline ForHtmlAttributeEscapeStringValue()
        {
            return new DotTextEscapingPipeline(
                CommonForEscapeString(),
                new DotHtmlEncodeEscaper()
            );
        }
    }
}