using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Edges.Enums
{
    /// <summary>
    ///     Modifies the edge placement to aim for the corresponding compass point on the port, or if no port name is supplied, on the
    ///     node itself.
    /// </summary>
    public enum DotCompassPoint
    {
        /// <summary>
        ///     Specifies that an appropriate side of the port adjacent to the exterior of the node should be used, if such exists.
        ///     Otherwise, <see cref="Center" /> is used.
        /// </summary>
        [DotAttributeValue("_")]
        Default,

        /// <summary>
        ///     Specifies the center of the node or port.
        /// </summary>
        [DotAttributeValue("c")]
        Center,

        /// <summary>
        ///     Specifies the northern side of the node or port.
        /// </summary>
        [DotAttributeValue("n")]
        North,

        /// <summary>
        ///     Specifies the north-eastern side of the node or port.
        /// </summary>
        [DotAttributeValue("ne")]
        NorthEast,


        /// <summary>
        ///     Specifies the eastern side of the node or port.
        /// </summary>
        [DotAttributeValue("e")]
        East,

        /// <summary>
        ///     Specifies the south-eastern side of the node or port.
        /// </summary>
        [DotAttributeValue("se")]
        SouthEast,

        /// <summary>
        ///     Specifies the southern side of the node or port.
        /// </summary>
        [DotAttributeValue("s")]
        South,

        /// <summary>
        ///     Specifies the south-western side of the node or port.
        /// </summary>
        [DotAttributeValue("sw")]
        SouthWest,

        /// <summary>
        ///     Specifies the western side of the node or port.
        /// </summary>
        [DotAttributeValue("w")]
        West,

        /// <summary>
        ///     Specifies the north-western side of the node or port.
        /// </summary>
        [DotAttributeValue("nw")]
        NorthWest
    }
}