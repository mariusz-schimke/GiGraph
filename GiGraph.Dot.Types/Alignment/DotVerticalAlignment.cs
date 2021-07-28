using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Metadata.Html;

namespace GiGraph.Dot.Types.Alignment
{
    /// <summary>
    ///     The vertical label alignment options.
    /// </summary>
    public enum DotVerticalAlignment
    {
        // NOTE! THE VALUES ARE USED BY THE DotAlignment ENUM AS FLAGS
        // THE VALUES ARE CONTINUED BY DotHorizontalAlignment

        /// <summary>
        ///     Places the label at the top of the element.
        /// </summary>
        [DotAttributeValue("t")]
        [DotHtmlElementAttributeValue("TOP")]
        Top = 1 << 0,

        /// <summary>
        ///     Places the label at the vertical center of the element.
        /// </summary>
        [DotAttributeValue("c")]
        [DotHtmlElementAttributeValue("MIDDLE")]
        Center = 1 << 1,

        /// <summary>
        ///     Places the label at the bottom of the element.
        /// </summary>
        [DotAttributeValue("b")]
        [DotHtmlElementAttributeValue("BOTTOM")]
        Bottom = 1 << 2
    }
}