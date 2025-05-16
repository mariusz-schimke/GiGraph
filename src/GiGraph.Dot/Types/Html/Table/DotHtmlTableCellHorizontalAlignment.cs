using GiGraph.Dot.Output.Metadata.Html;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Types.Html.Table;

/// <summary>
///     The justification options for HTML table cells.
/// </summary>
public enum DotHtmlTableCellHorizontalAlignment
{
    // NOTE! THE VALUES ARE USED BY THE DotAlignment ENUM AS FLAGS
    // THE VALUES CONTINUE FROM DotVerticalAlignment

    /// <summary>
    ///     Places the label at the left side of the element.
    /// </summary>
    [DotHtmlAttributeValue("LEFT")]
    Left = DotHorizontalAlignment.Left,

    /// <summary>
    ///     Places the label at the horizontal center of the element.
    /// </summary>
    [DotHtmlAttributeValue("CENTER")]
    Center = DotHorizontalAlignment.Center,

    /// <summary>
    ///     Places the label at the right side of the element.
    /// </summary>
    [DotHtmlAttributeValue("RIGHT")]
    Right = DotHorizontalAlignment.Right,

    /// <summary>
    ///     <para>
    ///         Aligns lines of text using the full cell width. The alignment of a line is determined by its (possibly implicit)
    ///         associated &lt;br/&gt; element (line break). If the cell contains lines of text, then they are justified using the entire
    ///         available width of the cell. If the cell does not contain text, then the contained image or table is centered.
    ///     </para>
    ///     <para>
    ///         Applicable to HTML table cell only (&lt;td&gt;).
    ///     </para>
    /// </summary>
    [DotHtmlAttributeValue("TEXT")]
    Justify = Right << 1
}