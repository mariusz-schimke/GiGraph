using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The vertical label alignment options.
    /// </summary>
    public enum DotVerticalAlignment
    {
        /// <summary>
        ///     Places the label at the top of the element.
        /// </summary>
        [DotAttributeValue("t")]
        Top,

        /// <summary>
        ///     Places the label at the vertical center of the element.
        /// </summary>
        [DotAttributeValue("c")]
        Center,

        /// <summary>
        ///     Places the label at the bottom of the element.
        /// </summary>
        [DotAttributeValue("b")]
        Bottom
    }
}