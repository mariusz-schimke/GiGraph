using GiGraph.Dot.Entities.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     Controls how, and if, edges are represented.
    /// </summary>
    public enum DotEdgeShape
    {
        /// <summary>
        ///     No edges are drawn.
        /// </summary>
        [DotAttributeValue("none")]
        None,

        /// <summary>
        ///     Edges are drawn as line segments.
        /// </summary>
        [DotAttributeValue("line")]
        Line,

        /// <summary>
        ///     Edges are drawn as polylines.
        /// </summary>
        [DotAttributeValue("polyline")]
        Polyline,

        /// <summary>
        ///     Edges are drawn as curved arcs.
        /// </summary>
        [DotAttributeValue("curved")]
        Curved,

        /// <summary>
        ///     Edges are routed as polylines of axis-aligned segments. Currently, the routing does not handle ports or, in DOT, edge labels.
        /// </summary>
        [DotAttributeValue("ortho")]
        Orthogonal,

        /// <summary>
        ///     Edges are drawn as splines routed around nodes.
        /// </summary>
        [DotAttributeValue("spline")]
        Spline,

        /// <summary>
        ///     Edges are drawn to avoid clusters as well as nodes.
        /// </summary>
        [DotAttributeValue("compound")]
        Compound
    }
}