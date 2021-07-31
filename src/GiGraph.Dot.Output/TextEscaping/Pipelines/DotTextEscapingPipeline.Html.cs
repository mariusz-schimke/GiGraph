using GiGraph.Dot.Output.TextEscaping.Escapers.Html;

namespace GiGraph.Dot.Output.TextEscaping.Pipelines
{
    public partial class DotTextEscapingPipeline
    {
        /// <summary>
        ///     Creates a new pipeline that escapes text for use as the content of an HTML element.
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
            // https://graphviz.org/doc/info/shapes.html#border
            // "HTML comments are allowed within an HTML string. They can occur anywhere provided that,
            //  if they contain part of an HTML element, they must contain the entire element."
            // Therefore I think it should undergo escaping similar to that of textual context of an element.
            // This will reduce readability of the comment, but will make sure it will not break the structure of the HTML document.
            return ForHtmlElementTextContent();
        }

        /// <summary>
        ///     Creates a new pipeline that escapes HTML attribute values in general.
        /// </summary>
        public static DotTextEscapingPipeline ForHtmlAttributeValue()
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