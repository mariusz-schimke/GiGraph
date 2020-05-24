namespace GiGraph.Dot.Entities.Nodes.Enums
{
    /// <summary>
    /// Modifies the edge placement to aim for the corresponding compass point on the port,
    /// or if no port name is supplied, on the node itself.
    /// </summary>
    public enum DotCompassPoint
    {
        /// <summary>
        /// Specifies that an appropriate side of the port adjacent to the exterior of the node should be used, if such exists.
        /// Otherwise, <see cref="Center"/> is used.
        /// </summary>
        Default,

        /// <summary>
        /// Specifies the center of the node or port.
        /// </summary>
        Center,

        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }
}
