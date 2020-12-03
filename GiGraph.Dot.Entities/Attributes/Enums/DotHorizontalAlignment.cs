using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The justification options for labels.
    /// </summary>
    public enum DotHorizontalAlignment
    {
        // NOTE! THE VALUES ARE USED BY THE DotAlignment ENUM AS FLAGS
        // THE VALUES CONTINUE FROM DotVerticalAlignment
        
        /// <summary>
        ///     Places the label at the left side of the element.
        /// </summary>
        [DotAttributeValue("l")]
        Left = 1 << 3,

        /// <summary>
        ///     Places the label at the horizontal center of the element.
        /// </summary>
        [DotAttributeValue("c")]
        Center = 1 << 4,

        /// <summary>
        ///     Places the label at the right side of the element.
        /// </summary>
        [DotAttributeValue("r")]
        Right = 1 << 5
    }
}