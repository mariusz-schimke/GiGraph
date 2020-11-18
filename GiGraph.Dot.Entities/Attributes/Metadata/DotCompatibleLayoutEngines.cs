using System;

namespace GiGraph.Dot.Entities.Attributes.Metadata
{
    /// <summary>
    ///     Determines layout engines that an attribute is used by.
    /// </summary>
    [Flags]
    public enum DotCompatibleLayoutEngines
    {
        /// <summary>
        ///     The attribute is used for output only, and is not used or read by any layout program.
        /// </summary>
        None = 0,

        /// <summary>
        ///     The attribute may be used by any layout engine.
        /// </summary>
        Any = -1,

        /// <summary>
        ///     “Hierarchical” or layered drawings of directed graphs. This is the default tool to use if edges have directionality.
        /// </summary>
        Dot = 1 << 0,

        /// <summary>
        ///     The attribute may be used by any layout engine, but is not used by <see cref="Dot" />.
        /// </summary>
        NotDot = 1 << 1,

        /// <summary>
        ///     An engine that draws “spring model” layouts. This is the default tool to use if the graph is not too large (about 100 nodes)
        ///     and you don't know anything else about it. Neato attempts to minimize a global energy function, which is equivalent to
        ///     statistical multi-dimensional scaling.
        /// </summary>
        Neato = 1 << 2,

        /// <summary>
        ///     An engine that draws “spring model” layouts similar to those of neato, but does this by reducing forces rather than working
        ///     with energy.
        /// </summary>
        Fdp = 1 << 3,

        /// <summary>
        ///     A multiscale version of <see cref="Fdp" /> for the layout of large graphs.
        /// </summary>
        Sfdp = 1 << 4,

        /// <summary>
        ///     An engine that draws circular layouts (after Six and Tollis 99, Kauffman and Wiese 02). This is suitable for certain diagrams
        ///     of multiple cyclic structures, such as certain telecommunications networks.
        /// </summary>
        Circo = 1 << 5,

        /// <summary>
        ///     An engine that draws radial layouts (after Graham Wills 97). Nodes are placed on concentric circles depending their distance
        ///     from a given root node.
        /// </summary>
        Twopi = 1 << 6,

        /// <summary>
        ///     An engine that draws the graph as a squarified treemap. The clusters of the graph are used to specify the tree.
        /// </summary>
        Patchwork = 1 << 7,

        /// <summary>
        ///     A PRoxImity Stress Model.
        /// </summary>
        Prism = 1 << 8
    }
}