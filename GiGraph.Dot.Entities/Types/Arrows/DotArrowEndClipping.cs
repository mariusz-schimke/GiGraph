namespace GiGraph.Dot.Entities.Types.Arrows
{
    /// <summary>
    ///     Determines which side of an arrow end to clip.
    /// </summary>
    public enum DotArrowEndClipping
    {
        /// <summary>
        ///     Does not clip the arrow end.
        /// </summary>
        None,

        /// <summary>
        ///     Clips the left side of the arrow end so that only the right half is visible.
        /// </summary>
        Left,

        /// <summary>
        ///     Clips the right side of the arrow end so that only the left half is visible.
        /// </summary>
        Right
    }
}