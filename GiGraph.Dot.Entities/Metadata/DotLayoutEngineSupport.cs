using System;

namespace GiGraph.Dot.Entities.Metadata
{
    /// <summary>
    ///     DOT layout engines.
    /// </summary>
    [Flags]
    public enum DotLayoutEngineSupport
    {
        /// <summary>
        ///     Any layout engine.
        /// </summary>
        Any = 0,

        /// <summary>
        ///     “Hierarchical” or layered drawings of directed graphs. This is the default tool to use if edges have directionality.
        /// </summary>
        Dot = 1 << 0,

        /// <summary>
        ///     All layout engines but dot.
        /// </summary>
        NotDot = 1 << 1,

        /// <summary>
        ///     “Spring model” layouts. This is the default tool to use if the graph is not too large (about 100 nodes) and you don't know
        ///     anything else about it. Neato attempts to minimize a global energy function, which is equivalent to statistical
        ///     multi-dimensional scaling.
        /// </summary>
        Neato = 1 << 2,

        /// <summary>
        ///     “Spring model” layouts similar to those of neato, but does this by reducing forces rather than working with energy.
        /// </summary>
        Fdp = 1 << 3,

        /// <summary>
        ///     Multiscale version of fdp for the layout of large graphs.
        /// </summary>
        Sfdp = 1 << 4,

        /// <summary>
        ///     Circular layout, after Six and Tollis 99, Kauffman and Wiese 02. This is suitable for certain diagrams of multiple cyclic
        ///     structures, such as certain telecommunications networks.
        /// </summary>
        Circo = 1 << 5,

        /// <summary>
        ///     Radial layouts, after Graham Wills 97. Nodes are placed on concentric circles depending their distance from a given root
        ///     node.
        /// </summary>
        Twopi = 1 << 6,

        /// <summary>
        ///     Draws the graph as a squarified treemap. The clusters of the graph are used to specify the tree.
        /// </summary>
        Patchwork = 1 << 7,

        /// <summary>
        ///     PRoxImity Stress Model
        /// </summary>
        Prism = 1 << 8
    }
}