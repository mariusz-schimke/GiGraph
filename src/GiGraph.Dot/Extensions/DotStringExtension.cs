using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html;

namespace GiGraph.Dot.Extensions;

public static class DotStringExtension
{
    /// <summary>
    ///     Converts the string to <see cref="DotEscapeString"/> without escaping its content. When assigned to a label of an element,
    ///     any markups used in the text can be correctly interpreted by the visualization engine. Make sure the content complies with
    ///     the DOT syntax rules as otherwise the output may become syntactically incorrect. Consider using
    ///     <see cref="DotFormattedTextBuilder"/> for formulating formatted text instead.
    /// </summary>
    /// <param name="string">
    ///     The string to convert.
    /// </param>
    [Pure]
    [return: NotNullIfNotNull(nameof(@string))]
    public static DotEscapeString? AsFormattedString(this string? @string) => (DotEscapedString?) @string;

    /// <summary>
    ///     Converts the string to <see cref="DotHtmlString"/> without modifying it in any way. When assigned to a label of an element,
    ///     it will be interpreted as HTML, not as plain text.
    /// </summary>
    /// <param name="string">
    ///     The string to convert.
    /// </param>
    [Pure]
    [return: NotNullIfNotNull(nameof(@string))]
    public static DotHtmlString? AsHtml(this string? @string) => @string;
}