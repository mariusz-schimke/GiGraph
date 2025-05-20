using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

/// <summary>
///     The hyperlink attributes of an HTML table (&lt;table&gt;) and an HTML table cell (&lt;td&gt;).
/// </summary>
public interface IDotHtmlTableTableCellHyperlinkAttributes
{
    /// <summary>
    ///     Attaches a URL to the object.
    /// </summary>
    DotEscapeString? Href { get; set; }

    /// <summary>
    ///     Determines which window of the browser is used for the URL if the object has one. See the
    ///     <see href="http://www.w3.org/TR/html401/present/frames.html#adef-target">
    ///         W3C documentation
    ///     </see>
    ///     or use one of the predefined values from <see cref="DotHyperlinkTargets"/>.
    /// </summary>
    DotEscapeString? Target { get; set; }

    /// <summary>
    ///     Sets the tooltip annotation attached to the element. This is used only if the element has a <see cref="Href"/> attribute.
    /// </summary>
    DotEscapeString? Title { get; set; }

    /// <summary>
    ///     Sets the tooltip annotation attached to the element. This is used only if the element has a <see cref="Href"/> attribute. It
    ///     is an alias for <see cref="Title"/>.
    /// </summary>
    DotEscapeString? Tooltip { get; set; }
}