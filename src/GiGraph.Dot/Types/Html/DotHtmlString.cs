using System;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Types.Html;

/// <summary>
///     Represents an HTML string. The value should be a compatible HTML string following the rules described in the
///     <see href="http://www.graphviz.org/doc/info/shapes.html#html">
///         documentation
///     </see>
///     .
/// </summary>
public class DotHtmlString : IDotHtmlEncodable
{
    protected readonly string _html;

    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    /// <param name="html">
    ///     The HTML string to initialize the instance with.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the <paramref name="html" /> is null.
    /// </exception>
    public DotHtmlString(string html)
    {
        _html = html ?? throw new ArgumentNullException(nameof(html), "HTML string must not be null.");
    }

    string IDotHtmlEncodable.ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => _html;

    public override string ToString() => _html;

    public static implicit operator DotHtmlString(string value) => value is not null ? new DotHtmlString(value) : null;

    public static implicit operator string(DotHtmlString value) => value?._html;

    public static implicit operator DotUnescapedString(DotHtmlString value) => value?._html;

    public static DotHtmlString operator +(DotHtmlString value1, DotHtmlString value2) => value1?._html + value2?._html;
}