﻿namespace GiGraph.Dot.Entities.Attributes.Enums
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
        /// Edges are routed as polylines of axis-aligned segments. Currently, the routing does not handle ports or, in DOT, edge labels.
        /// </summary>
        Orthogonal,

        /// <summary>
        /// Edges are drawn as splines routed around nodes.
        /// </summary>
        Spline,

        /// <summary>
        /// Edges are drawn to avoid clusters as well as nodes.
        /// </summary>
        Compound
    }
}