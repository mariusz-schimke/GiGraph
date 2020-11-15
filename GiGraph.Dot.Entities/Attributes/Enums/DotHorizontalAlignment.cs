using GiGraph.Dot.Entities.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The justification options for labels.
    /// </summary>
    public enum DotHorizontalAlignment
    {
        /// <summary>
        ///     Places the label at the left side of the element.
        /// </summary>
        [DotAttributeValue("l")]
        Left,

        /// <summary>
        ///     Places the label at the horizontal center of the element.
        /// </summary>
        [DotAttributeValue("c")]
        Center,

        /// <summary>
        ///     Places the label at the right side of the element.
        /// </summary>
        [DotAttributeValue("r")]
        Right
    }
}