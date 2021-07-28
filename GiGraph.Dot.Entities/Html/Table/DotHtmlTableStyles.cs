using System;
using GiGraph.Dot.Output.Metadata.Html;

namespace GiGraph.Dot.Entities.Html.Table
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
        [DotHtmlElementAttributeValue("ROUNDED")]
        Rounded = 1 << 0,

        /// <summary>
        ///     Specifies a radial style for the element.
        /// </summary>
        [DotHtmlElementAttributeValue("RADIAL")]
        Radial = 1 << 1
    }
}