using GiGraph.Dot.Output.Metadata.Html;

namespace GiGraph.Dot.Types.Html.Table;

/// <summary>
///     The borders of an HTML table or cell.
/// </summary>
[Flags]
[DotHtmlJoinableType(separator: "", order: false)]
public enum DotHtmlTableBorders
{
    /// <summary>
    ///     The top border.
    /// </summary>
    [DotHtmlAttributeValue("T")]
    Top = 1 << 0,

    /// <summary>
    ///     The right border.
    /// </summary>
    [DotHtmlAttributeValue("R")]
    Right = 1 << 1,

    /// <summary>
    ///     The bottom border.
    /// </summary>
    [DotHtmlAttributeValue("B")]
    Bottom = 1 << 2,

    /// <summary>
    ///     The left border.
    /// </summary>
    [DotHtmlAttributeValue("L")]
    Left = 1 << 3,

    /// <summary>
    ///     The top and bottom borders.
    /// </summary>
    Horizontal = Top | Bottom,

    /// <summary>
    ///     The left and right borders.
    /// </summary>
    Vertical = Left | Right,

    /// <summary>
    ///     All borders.
    /// </summary>
    All = Horizontal | Vertical
}