using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
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
}