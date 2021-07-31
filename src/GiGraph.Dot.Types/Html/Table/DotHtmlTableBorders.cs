using System;
using GiGraph.Dot.Output.Metadata.Html;

namespace GiGraph.Dot.Types.Html.Table
{
    /// <summary>
    ///     The sides of a border of an HTML table or cell.
    /// </summary>
    [Flags]
    [DotHtmlElementJoinableType(separator: "")]
    public enum DotHtmlTableBorders
    {
        /// <summary>
        ///     The top border.
        /// </summary>
        [DotHtmlElementAttributeValue("T")]
        Top = 1 << 0,

        /// <summary>
        ///     The right border.
        /// </summary>
        [DotHtmlElementAttributeValue("R")]
        Right = 1 << 1,

        /// <summary>
        ///     The bottom border.
        /// </summary>
        [DotHtmlElementAttributeValue("B")]
        Bottom = 1 << 2,

        /// <summary>
        ///     The left border.
        /// </summary>
        [DotHtmlElementAttributeValue("L")]
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
}