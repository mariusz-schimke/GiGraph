namespace GiGraph.Dot.Entities.Types.Arrows
{
    /// <summary>
    ///     Determines the parts of an arrowhead. Left and right are defined as those directions determined by looking from the edge
    ///     towards the point where the arrow "touches" the node.
    /// </summary>
    public enum DotArrowheadParts
    {
        /// <summary>
        ///     Both parts of the arrowhead.
        /// </summary>
        Both,

        /// <summary>
        ///     The left part of the arrowhead.
        /// </summary>
        Left,

        /// <summary>
        ///     The right part of the arrowhead.
        /// </summary>
        Right
    }
}