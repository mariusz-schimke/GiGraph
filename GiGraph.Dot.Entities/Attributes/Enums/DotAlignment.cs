using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     Determines how an image is positioned within its containing element.
    /// </summary>
    public enum DotAlignment
    {
        /// <summary>
        ///     Top left.
        /// </summary>
        [DotAttributeValue("tl")]
        TopLeft,

        /// <summary>
        ///     Top centered.
        /// </summary>
        [DotAttributeValue("tc")]
        TopCenter,

        /// <summary>
        ///     Top right.
        /// </summary>
        [DotAttributeValue("tr")]
        TopRight,

        /// <summary>
        ///     Middle left.
        /// </summary>
        [DotAttributeValue("ml")]
        MiddleLeft,

        /// <summary>
        ///     Middle centered.
        /// </summary>
        [DotAttributeValue("mc")]
        MiddleCenter,

        /// <summary>
        ///     Middle right.
        /// </summary>
        [DotAttributeValue("mr")]
        MiddleRight,

        /// <summary>
        ///     Middle left.
        /// </summary>
        [DotAttributeValue("bl")]
        BottomLeft,

        /// <summary>
        ///     Bottom centered.
        /// </summary>
        [DotAttributeValue("bc")]
        BottomCenter,

        /// <summary>
        ///     Bottom right.
        /// </summary>
        [DotAttributeValue("br")]
        BottomRight
    }
}