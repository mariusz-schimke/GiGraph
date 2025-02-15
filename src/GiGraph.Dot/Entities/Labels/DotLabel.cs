using System.Diagnostics.CodeAnalysis;
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
    string? IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncodedString(options, syntaxRules);

    protected abstract string? GetDotEncodedString(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

    /// <summary>
    ///     Creates a label initialized with the specified text.
    /// </summary>
    /// <param name="text">
    ///     The text to use as the label.
    /// </param>
    [return: NotNullIfNotNull(nameof(text))]
    public static DotLabel? FromText(string? text) => text;

    /// <summary>
    ///     Creates a label initialized with formatted text. The text should be formatted and escaped according to the rules described in
    ///     the
    ///     <see href="https://www.graphviz.org/docs/attr-types/escString">
    ///         escape string documentation
    ///     </see>
    ///     . If the text represents a record, its format should follow the rules described in the
    ///     <see href="https://www.graphviz.org/doc/info/shapes.html#record">
    ///         record-shaped node documentation
    ///     </see>
    ///     .
    /// </summary>
    /// <param name="text">
    ///     The escaped text to use as the label.
    /// </param>
    [return: NotNullIfNotNull(nameof(text))]
    public static DotLabel? FromFormattedText(string? text) => (DotEscapedString) text;

    /// <summary>
    ///     Creates an HTML label. The HTML should be generated according to the rules described in the
    ///     <see href="https://www.graphviz.org/doc/info/shapes.html#html">
    ///         documentation
    ///     </see>
    ///     .
    /// </summary>
    /// <param name="html">
    ///     The HTML to use as the label.
    /// </param>
    [return: NotNullIfNotNull(nameof(html))]
    public static DotLabel? FromHtml(string? html) => html is not null ? new DotHtmlLabel(html) : null;

    /// <summary>
    ///     Creates an HTML label.
    /// </summary>
    /// <param name="htmlEntity">
    ///     The HTML entity to use as the label.
    /// </param>
    [return: NotNullIfNotNull(nameof(htmlEntity))]
    public static DotLabel? FromHtml(IDotHtmlEntity? htmlEntity) => htmlEntity is not null ? new DotHtmlLabel(htmlEntity) : null;

    /// <summary>
    ///     Creates a label initialized with the specified record.
    /// </summary>
    /// <param name="record">
    ///     The record to use as the label.
    /// </param>
    [return: NotNullIfNotNull(nameof(record))]
    public static DotLabel? FromRecord(DotRecord? record) => record;

    [return: NotNullIfNotNull(nameof(text))]
    public static implicit operator DotLabel?(string? text) => text is not null ? new DotTextLabel(text) : null;

    [return: NotNullIfNotNull(nameof(text))]
    public static implicit operator DotLabel?(DotEscapeString? text) => text is not null ? new DotTextLabel(text) : null;

    [return: NotNullIfNotNull(nameof(record))]
    public static implicit operator DotLabel?(DotRecord? record) => record is not null ? new DotRecordLabel(record) : null;

    [return: NotNullIfNotNull(nameof(html))]
    public static implicit operator DotLabel?(DotHtmlString? html) => html is not null ? new DotHtmlLabel(html) : null;

    [return: NotNullIfNotNull(nameof(htmlEntity))]
    public static implicit operator DotLabel?(DotHtmlEntity? htmlEntity) => htmlEntity is not null ? new DotHtmlLabel(htmlEntity) : null;

    [return: NotNullIfNotNull(nameof(htmlEntityCollection))]
    public static implicit operator DotLabel?(DotHtmlEntityCollection? htmlEntityCollection) =>
        htmlEntityCollection is not null ? new DotHtmlLabel(htmlEntityCollection) : null;
}