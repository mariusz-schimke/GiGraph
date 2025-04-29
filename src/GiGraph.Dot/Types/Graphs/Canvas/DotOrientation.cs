using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Types.Graphs.Canvas;

/// <summary>
///     The orientation options.
/// </summary>
public enum DotOrientation
{
    /// <summary>
    ///     Vertical orientation.
    /// </summary>
    [DotAttributeValue("portrait")]
    Portrait,

    /// <summary>
    ///     Horizontal orientation.
    /// </summary>
    [DotAttributeValue("landscape")]
    Landscape
}