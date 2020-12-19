using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Enums
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
        Top = 1 << 0,

        /// <summary>
        ///     Places the label at the vertical center of the element.
        /// </summary>
        [DotAttributeValue("c")]
        Center = 1 << 1,

        /// <summary>
        ///     Places the label at the bottom of the element.
        /// </summary>
        [DotAttributeValue("b")]
        Bottom = 1 << 2
    }
}