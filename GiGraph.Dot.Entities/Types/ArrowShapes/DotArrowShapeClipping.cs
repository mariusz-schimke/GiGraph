namespace GiGraph.Dot.Entities.Types.ArrowShapes
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
        ///     Clip the shape, leaving only the part to the left of the edge.
        /// </summary>
        Left,

        /// <summary>
        ///     Clip the shape, leaving only the part to the right of the edge.
        /// </summary>
        Right
    }
}