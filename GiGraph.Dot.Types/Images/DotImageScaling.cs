using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Types.Images
{
    /// <summary>
    ///     Image scaling options.
    /// </summary>
    public enum DotImageScaling
    {
        /// <summary>
        ///     The image retains its natural size.
        /// </summary>
        [DotAttributeValue("false")]
        None,

        /// <summary>
        ///     The image is uniformly scaled (i.e., its aspect ratio is preserved) to fit inside the node. At least one dimension of the
        ///     image will be as large as possible given the size of the node.
        /// </summary>
        [DotAttributeValue("true")]
        Uniform,

        /// <summary>
        ///     The width of the image is scaled to fill the node width.
        /// </summary>
        [DotAttributeValue("width")]
        FillWidth,

        /// <summary>
        ///     The height of the image is scaled to fill the node height.
        /// </summary>
        [DotAttributeValue("height")]
        FillHeight,

        /// <summary>
        ///     Both the height and the width are scaled separately to fill the node.
        /// </summary>
        [DotAttributeValue("both")]
        FillBoth
    }
}