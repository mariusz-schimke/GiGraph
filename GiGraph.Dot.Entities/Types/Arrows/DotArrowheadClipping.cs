namespace GiGraph.Dot.Entities.Types.Arrows
{
    /// <summary>
    ///     Determines which side of an arrowhead to clip.
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