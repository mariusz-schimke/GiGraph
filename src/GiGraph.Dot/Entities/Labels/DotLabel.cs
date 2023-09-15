using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html;
using GiGraph.Dot.Types.Records;

namespace GiGraph.Dot.Entities.Labels;

/// <summary>
///     Represents label. It can either be a text label (<see cref="DotTextLabel" />), or an HTML label ( <see cref="DotHtmlLabel" />
///     ). <see cref="DotRecordLabel" />, on the other hand, can be used for record-like nodes.
/// </summary>
public abstract class DotLabel : IDotEncodable
{
    string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncodedString(options, syntaxRules);

    protected abstract string GetDotEncodedString(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

    /// <summary>
    ///     Creates a label initialized with the specified text.
    /// </summary>
    /// <param name="text">
    ///     The text to use as the label.
    /// </param>
    public static DotLabel FromText(string text) => new DotTextLabel(text);

    /// <summary>
    ///     Creates a label initialized with formatted text. The text should be formatted and escaped according to the rules described in
    ///     the
    ///     <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString">
    ///         escape string documentation
    ///     </see>
    ///     . If the text represents a record, its format should follow the rules described in the
    ///     <see href="http://www.graphviz.org/doc/info/shapes.html#record">
    ///         record-shaped node documentation
    ///     </see>
    ///     .
    /// </summary>
    /// <param name="text">
    ///     The escaped text to use as the label.
    /// </param>
    public static DotLabel FromFormattedText(string text) => new DotTextLabel((DotEscapedString) text);

    /// <summary>
    ///     Creates an HTML label. The HTML should be generated according to the rules described in the
    ///     <see href="http://www.graphviz.org/doc/info/shapes.html#html">
    ///         documentation
    ///     </see>
    ///     .
    /// </summary>
    /// <param name="html">
    ///     The HTML to use as the label.
    /// </param>
    public static DotLabel FromHtml(string html) => new DotHtmlLabel(html);

    /// <summary>
    ///     Creates an HTML label.
    /// </summary>
    /// <param name="htmlEntity">
    ///     The HTML entity to use as the label.
    /// </param>
    public static DotLabel FromHtml(IDotHtmlEntity htmlEntity) => new DotHtmlLabel(htmlEntity);

    /// <summary>
    ///     Creates a label initialized with the specified record.
    /// </summary>
    /// <param name="record">
    ///     The record to use as the label.
    /// </param>
    public static DotLabel FromRecord(DotRecord record) => new DotRecordLabel(record);

    public static implicit operator DotLabel(string text) => text is not null ? new DotTextLabel(text) : null;

    public static implicit operator DotLabel(DotEscapeString text) => text is not null ? new DotTextLabel(text) : null;

    public static implicit operator DotLabel(DotRecord record) => record is not null ? new DotRecordLabel(record) : null;

    public static implicit operator DotLabel(DotHtmlString html) => html is not null ? new DotHtmlLabel(html) : null;

    public static implicit operator DotLabel(DotHtmlEntity htmlEntity) => htmlEntity is not null ? new DotHtmlLabel(htmlEntity) : null;

    public static implicit operator DotLabel(DotHtmlEntityCollection htmlEntityCollection) => htmlEntityCollection is not null ? new DotHtmlLabel(htmlEntityCollection) : null;
}