namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    /// Controls how, and if, edges are represented.
    /// </summary>
    public enum DotEdgeShape
    {
        /// <summary>
        /// No edges are drawn.
        /// </summary>
        None,

        /// <summary>
        /// Edges are drawn as line segments.
        /// </summary>
        Line,

        /// <summary>
        /// Edges are drawn as polylines.
        /// </summary>
        Polyline,

        /// <summary>
        /// Edges are drawn as curved arcs.
        /// </summary>
        Curved,

        /// <summary>
        /// Edges are routed as polylines of axis-aligned segments.
        /// </summary>
        Ortho,

        /// <summary>
        /// Edges are drawn as splines routed around nodes.
        /// </summary>
        Spline
    }
}