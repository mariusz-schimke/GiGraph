using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.Html;

namespace GiGraph.Dot.Entities.Labels;

/// <summary>
///     Represents an HTML label with an underlying object capable of being converted to HTML on DOT output rendering.
/// </summary>
public class DotHtmlLabel : DotLabel
{
    protected readonly IDotHtmlEncodable _value;

    /// <summary>
    ///     Creates a new label instance.
    /// </summary>
    /// <param name="htmlEntity">
    ///     The object capable of being converted to HTML.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="htmlEntity" /> is null.
    /// </exception>
    public DotHtmlLabel(IDotHtmlEntity htmlEntity)
    {
        _value = htmlEntity ?? throw new ArgumentNullException(nameof(htmlEntity), "HTML entity must not be null.");
    }

    /// <summary>
    ///     Creates a new HTML string label.
    /// </summary>
    /// <param name="html">
    ///     The HTML text to use. It is expected to be a compatible HTML string following the rules described in the
    ///     <see href="https://www.graphviz.org/doc/info/shapes.html#html">
    ///         documentation
    ///     </see>
    ///     .
    /// </param>
    public DotHtmlLabel(string html)
    {
        _value = (DotHtmlString) html ?? throw new ArgumentNullException(nameof(html), "HTML string must not be null.");
    }

    protected override string GetDotEncodedString(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => _value.ToHtml(options, syntaxRules);

    public override string? ToString() => _value.ToString();
}