using System;
using GiGraph.Dot.Output.Metadata.Html;

namespace GiGraph.Dot.Entities.Html.Table
{
    /// <summary>
    ///     The sides of a border of an HTML table or cell.
    /// </summary>
    [Flags]
    [DotHtmlElementFlags(separator: "")]
    public enum DotHtmlTableSides
    {
        /// <summary>
        ///     The top side of the border.
        /// </summary>
        [DotHtmlElementAttributeValue("T")]
        Top = 1 << 0,

        /// <summary>
        ///     The right side of the border.
        /// </summary>
        [DotHtmlElementAttributeValue("R")]
        Right = 1 << 1,

        /// <summary>
        ///     The bottom side of the border.
        /// </summary>
        [DotHtmlElementAttributeValue("B")]
        Bottom = 1 << 2,

        /// <summary>
        ///     The left side of the border.
        /// </summary>
        [DotHtmlElementAttributeValue("L")]
        Left = 1 << 3
    }
}