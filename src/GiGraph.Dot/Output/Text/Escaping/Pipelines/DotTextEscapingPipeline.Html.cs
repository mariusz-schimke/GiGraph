using System.Diagnostics.Contracts;
using GiGraph.Dot.Output.Text.Escaping.Html;

namespace GiGraph.Dot.Output.Text.Escaping.Pipelines;

public partial class DotTextEscapingPipeline
{
    /// <summary>
    ///     Creates a new pipeline that escapes text for use as the content of an HTML element.
    /// </summary>
    [Pure]
    public static DotTextEscapingPipeline ForHtmlElementTextContent() => new(new DotHtmlEncodeEscaper());

    /// <summary>
    ///     Creates a new pipeline that escapes HTML comment tag text.
    /// </summary>
    /// <remarks>
    ///     "HTML comments are allowed within an HTML string. They can occur anywhere provided that, if they contain part of an HTML
    ///     element, they must contain the entire element." Therefore I think it should undergo escaping similar to that of textual
    ///     context of an element. This will reduce readability of the comment, but will make sure it will not break the structure of the
    ///     HTML document. See
    ///     <see href="https://www.graphviz.org/doc/info/shapes.html#html">
    ///         documentation
    ///     </see>
    ///     .
    /// </remarks>
    [Pure]
    public static DotTextEscapingPipeline ForHtmlCommentText() => ForHtmlElementTextContent();

    /// <summary>
    ///     Creates a new pipeline that escapes HTML attribute values in general.
    /// </summary>
    [Pure]
    public static DotTextEscapingPipeline ForHtmlAttributeValue() => new(new DotHtmlEncodeEscaper());

    /// <summary>
    ///     Creates a new pipeline that escapes HTML attribute value of the escape string type.
    /// </summary>
    [Pure]
    public static DotTextEscapingPipeline ForHtmlAttributeEscapeStringValue() => new(CommonForEscapeString(), new DotHtmlEncodeEscaper());
}