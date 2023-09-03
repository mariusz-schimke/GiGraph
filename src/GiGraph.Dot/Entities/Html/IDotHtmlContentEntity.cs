using System;
using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html;

public interface IDotHtmlContentEntity : IDotHtmlEntity
{
    /// <summary>
    ///     Gets the content items of the element.
    /// </summary>
    DotHtmlEntityCollection Content { get; }

    /// <summary>
    ///     Uses the specified HTML entity as the content of the current element.
    /// </summary>
    /// <param name="entity">
    ///     The element to set as the content.
    /// </param>
    void SetContent(IDotHtmlEntity entity);

    /// <summary>
    ///     Uses the specified text as the content of the current element.
    /// </summary>
    /// <param name="text">
    ///     The text to set as the content.
    /// </param>
    /// <param name="lineAlignment">
    ///     Specifies horizontal placement of lines if multiline text is specified.
    /// </param>
    void SetContent(string text, DotHorizontalAlignment? lineAlignment = null);

    /// <summary>
    ///     Uses the builder to build a HTML entity to use as the content of the current element.
    /// </summary>
    /// <param name="build">
    ///     The HTML builder delegate.
    /// </param>
    void SetContent(Action<DotHtmlBuilder> build);

    /// <summary>
    ///     Uses the specified HTML as the content of the current element.
    /// </summary>
    /// <param name="html">
    ///     The HTML to use as the content.
    /// </param>
    void SetHtmlContent(string html);
}