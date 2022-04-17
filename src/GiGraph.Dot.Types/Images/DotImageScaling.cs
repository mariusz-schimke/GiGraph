using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Metadata.Html;

namespace GiGraph.Dot.Types.Images;

/// <summary>
///     Image scaling options.
/// </summary>
public enum DotImageScaling
{
    /// <summary>
    ///     The image retains its natural size.
    /// </summary>
    [DotAttributeValue("false")]
    [DotHtmlAttributeValue("FALSE")]
    None,

    /// <summary>
    ///     The image is uniformly scaled (i.e., its aspect ratio is preserved) to fit inside the node or table cell. At least one
    ///     dimension of the image will be as large as possible given the size of the node.
    /// </summary>
    [DotAttributeValue("true")]
    [DotHtmlAttributeValue("TRUE")]
    Uniform,

    /// <summary>
    ///     The width of the image is scaled to fill the node or table cell width.
    /// </summary>
    [DotAttributeValue("width")]
    [DotHtmlAttributeValue("WIDTH")]
    FillWidth,

    /// <summary>
    ///     The height of the image is scaled to fill the node or table cell height.
    /// </summary>
    [DotAttributeValue("height")]
    [DotHtmlAttributeValue("HEIGHT")]
    FillHeight,

    /// <summary>
    ///     Both the height and the width are scaled separately to fill the node or table cell.
    /// </summary>
    [DotAttributeValue("both")]
    [DotHtmlAttributeValue("BOTH")]
    FillBoth
}