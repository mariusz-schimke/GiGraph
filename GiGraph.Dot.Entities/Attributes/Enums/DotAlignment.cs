using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     Determines how an element is positioned within its containing element.
    /// </summary>
    public enum DotAlignment
    {
        /// <summary>
        ///     Top left.
        /// </summary>
        [DotAttributeValue("tl")]
        TopLeft = DotVerticalAlignment.Top | DotHorizontalAlignment.Left,

        /// <summary>
        ///     Top centered.
        /// </summary>
        [DotAttributeValue("tc")]
        TopCenter = DotVerticalAlignment.Top | DotHorizontalAlignment.Center,

        /// <summary>
        ///     Top right.
        /// </summary>
        [DotAttributeValue("tr")]
        TopRight = DotVerticalAlignment.Top | DotHorizontalAlignment.Right,

        /// <summary>
        ///     Middle left.
        /// </summary>
        [DotAttributeValue("ml")]
        MiddleLeft = DotVerticalAlignment.Center | DotHorizontalAlignment.Left,

        /// <summary>
        ///     Middle centered.
        /// </summary>
        [DotAttributeValue("mc")]
        MiddleCenter = DotVerticalAlignment.Center | DotHorizontalAlignment.Center,

        /// <summary>
        ///     Middle right.
        /// </summary>
        [DotAttributeValue("mr")]
        MiddleRight = DotVerticalAlignment.Center | DotHorizontalAlignment.Right,

        /// <summary>
        ///     Middle left.
        /// </summary>
        [DotAttributeValue("bl")]
        BottomLeft = DotVerticalAlignment.Bottom | DotHorizontalAlignment.Left,

        /// <summary>
        ///     Bottom centered.
        /// </summary>
        [DotAttributeValue("bc")]
        BottomCenter = DotVerticalAlignment.Bottom | DotHorizontalAlignment.Center,

        /// <summary>
        ///     Bottom right.
        /// </summary>
        [DotAttributeValue("br")]
        BottomRight = DotVerticalAlignment.Bottom | DotHorizontalAlignment.Right
    }
}