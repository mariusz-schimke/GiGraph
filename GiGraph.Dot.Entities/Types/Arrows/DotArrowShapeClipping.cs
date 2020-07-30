namespace GiGraph.Dot.Entities.Types.Arrows
{
    /// <summary>
    ///     Determines arrow shape clipping.
    /// </summary>
    public enum DotArrowShapeClipping
    {
        /// <summary>
        ///     Don't clip the arrow shape.
        /// </summary>
        None,

        /// <summary>
        ///     Clip the left side of the shape so that only the right half is visible.
        /// </summary>
        Left,

        /// <summary>
        ///     Clip the right side of the shape so that only the left half is visible.
        /// </summary>
        Right
    }
}