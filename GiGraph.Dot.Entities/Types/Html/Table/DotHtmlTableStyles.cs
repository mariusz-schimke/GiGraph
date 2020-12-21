using System;
using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Types.Html.Table
{
    /// <summary>
    ///     The sides of a border of an HTML table or cell.
    /// </summary>
    [Flags]
    public enum DotHtmlTableStyles
    {
        /// <summary>
        ///     Specifies rounded corners for the element.
        /// </summary>
        [DotAttributeValue("ROUNDED")]
        Rounded = 1 << 0,

        /// <summary>
        ///     Specifies a radial style for the element.
        /// </summary>
        [DotAttributeValue("RADIAL")]
        Radial = 1 << 1
    }
}