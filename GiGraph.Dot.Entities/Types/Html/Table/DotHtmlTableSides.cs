using System;
using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Types.Html.Table
{
    /// <summary>
    ///     The sides of a border of an HTML table or cell.
    /// </summary>
    [Flags]
    public enum DotHtmlTableSides
    {
        /// <summary>
        ///     The top side of the border.
        /// </summary>
        [DotAttributeValue("T")]
        Top = 1 << 0,

        /// <summary>
        ///     The right side of the border.
        /// </summary>
        [DotAttributeValue("R")]
        Right = 1 << 1,

        /// <summary>
        ///     The bottom side of the border.
        /// </summary>
        [DotAttributeValue("B")]
        Bottom = 1 << 2,

        /// <summary>
        ///     The left side of the border.
        /// </summary>
        [DotAttributeValue("L")]
        Left = 1 << 3
    }
}