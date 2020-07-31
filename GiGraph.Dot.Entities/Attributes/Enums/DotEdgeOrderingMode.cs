namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The edge ordering mode.
    /// </summary>
    public enum DotEdgeOrderingMode
    {
        /// <summary>
        ///     Default ordering.
        /// </summary>
        None,

        /// <summary>
        ///     The outedges of a node, that is, edges with the node as their tail node, must appear left-to-right in the same order in which
        ///     they are defined in the input.
        /// </summary>
        Outedge,

        /// <summary>
        ///     The inedges of a node, that is, edges with the node as their head node, must appear left-to-right in the same order in which
        ///     they are defined in the input.
        /// </summary>
        Inedge
    }
}