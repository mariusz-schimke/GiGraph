using System;

namespace GiGraph.Dot.Entities.Attributes.Metadata
{
    /// <summary>
    ///     Attribute support per element type.
    /// </summary>
    [Flags]
    public enum DotElementSupport
    {
        /// <summary>
        ///     An attribute is applicable to the root graph.
        /// </summary>
        Graph = 1 << 0,

        /// <summary>
        ///     An attribute is applicable to subgraphs.
        /// </summary>
        Subgraph = 1 << 1,

        /// <summary>
        ///     An attribute is applicable to clusters.
        /// </summary>
        Cluster = 1 << 2,

        /// <summary>
        ///     An attribute is applicable to nodes.
        /// </summary>
        Node = 1 << 3,

        /// <summary>
        ///     An attribute is applicable to edges.
        /// </summary>
        Edge = 1 << 4
    }
}