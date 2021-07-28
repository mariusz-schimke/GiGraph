using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Types.Alignment
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
        [DotHtmlElementAttributeValue("LEFT")]
        Left = 1 << 3,

        /// <summary>
        ///     Places the label at the horizontal center of the element.
        /// </summary>
        [DotAttributeValue("c")]
        [DotHtmlElementAttributeValue("CENTER")]
        Center = 1 << 4,

        /// <summary>
        ///     Places the label at the right side of the element.
        /// </summary>
        [DotAttributeValue("r")]
        [DotHtmlElementAttributeValue("RIGHT")]
        Right = 1 << 5
    }
}