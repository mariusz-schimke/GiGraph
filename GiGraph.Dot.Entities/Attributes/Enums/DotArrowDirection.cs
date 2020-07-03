namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    /// The arrow direction.
    /// <see href="https://www.graphviz.org/doc/info/attrs.html#k:dirType">View how individual arrow directions are visualized</see>.
    /// </summary>
    public enum DotArrowDirection
    {
        /// <summary>
        /// Draws an edge with no arrows.
        /// </summary>
        None,

        /// <summary>
        /// Draws an edge with one arrow pointing at the head node.
        /// </summary>
        Forward,

        /// <summary>
        /// Draws an edge with one arrow pointing at the tail node.
        /// </summary>
        Backward,

        /// <summary>
        /// Draws an edge with two arrows: one pointing at the tail node, and the other pointing at the head node.
        /// </summary>
        Both
    }
}