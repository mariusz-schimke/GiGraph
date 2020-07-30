namespace GiGraph.Dot.Entities.Types.Arrows
{
    /// <summary>
    ///     Determines which side of an arrowhead to clip. Left and right are defined as those directions determined by looking from the
    ///     edge towards the point where the arrow "touches" the node.
    /// </summary>
    public enum DotArrowheadClipping
    {
        /// <summary>
        ///     Does not clip the arrowhead.
        /// </summary>
        None,

        /// <summary>
        ///     Clips the left side of the arrowhead so that only the right half is visible.
        /// </summary>
        Left,

        /// <summary>
        ///     Clips the right side of the arrowhead so that only the left half is visible.
        /// </summary>
        Right
    }
}