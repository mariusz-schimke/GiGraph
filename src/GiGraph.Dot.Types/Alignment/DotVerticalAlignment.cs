using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Metadata.Html;

namespace GiGraph.Dot.Types.Alignment;

/// <summary>
///     The vertical label alignment options.
/// </summary>
public enum DotVerticalAlignment
{
    // NOTE! THE VALUES ARE USED BY THE DotAlignment ENUM AS FLAGS
    // THE VALUES ARE CONTINUED BY DotHorizontalAlignment

    /// <summary>
    ///     Places the object on the top.
    /// </summary>
    [DotAttributeValue("t")]
    [DotHtmlAttributeValue("TOP")]
    Top = 1 << 0,

    /// <summary>
    ///     Places the object in the vertical center.
    /// </summary>
    [DotAttributeValue("c")]
    [DotHtmlAttributeValue("MIDDLE")]
    Center = 1 << 1,

    /// <summary>
    ///     Places the object on the bottom.
    /// </summary>
    [DotAttributeValue("b")]
    [DotHtmlAttributeValue("BOTTOM")]
    Bottom = 1 << 2
}