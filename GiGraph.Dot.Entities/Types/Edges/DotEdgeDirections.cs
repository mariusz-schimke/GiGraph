using System;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Types.Edges
{
    /// <summary>
    ///     The arrow direction.
    ///     <see href="https://www.graphviz.org/doc/info/attrs.html#k:dirType">
    ///         View how individual arrow directions are visualized
    ///     </see>
    ///     .
    /// </summary>
    [Flags]
    public enum DotEdgeDirections
    {
        /// <summary>
        ///     Draws an edge with no arrows.
        /// </summary>
        [DotAttributeValue("none")]
        None = 0,

        /// <summary>
        ///     Draws an edge with one arrow pointing at the tail node.
        /// </summary>
        [DotAttributeValue("back")]
        Backward = 1 << 0,

        /// <summary>
        ///     Draws an edge with one arrow pointing at the head node.
        /// </summary>
        [DotAttributeValue("forward")]
        Forward = 1 << 1,

        /// <summary>
        ///     Draws an edge with two arrows: one pointing at the tail node, and the other pointing at the head node.
        /// </summary>
        [DotAttributeValue("both")]
        Both = Backward | Forward
    }
}