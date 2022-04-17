using System;

namespace GiGraph.Dot.Output.Metadata;

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
    ///     The attribute is used by the dot layout engine that draws “hierarchical” or layered drawings of directed graphs. This is the
    ///     default tool to use if edges have directionality.
    /// </summary>
    Dot = 1 << 0,

    /// <summary>
    ///     The attribute may be used by any layout engine, but is not used by <see cref="Dot" />.
    /// </summary>
    NotDot = 1 << 1,

    /// <summary>
    ///     The attribute is used by the neato layout engine that draws “spring model” layouts. This is the default tool to use if the
    ///     graph is not too large (about 100 nodes) and you don't know anything else about it. Neato attempts to minimize a global
    ///     energy function, which is equivalent to statistical multi-dimensional scaling.
    /// </summary>
    Neato = 1 << 2,

    /// <summary>
    ///     The attribute is used by the fdp layout engine that draws “spring model” layouts similar to those of <see cref="Neato" />,
    ///     but does this by reducing forces rather than working with energy.
    /// </summary>
    Fdp = 1 << 3,

    /// <summary>
    ///     The attribute is used by the sfdp layout engine. It is a multiscale version of <see cref="Fdp" /> for the layout of large
    ///     graphs.
    /// </summary>
    Sfdp = 1 << 4,

    /// <summary>
    ///     The attribute is used by the circo layout engine that draws circular layouts. This is suitable for certain diagrams of
    ///     multiple cyclic structures, such as certain telecommunications networks.
    /// </summary>
    Circo = 1 << 5,

    /// <summary>
    ///     The attribute is used by the twopi layout engine that draws radial layouts. Nodes are placed on concentric circles depending
    ///     their distance from a given root node.
    /// </summary>
    Twopi = 1 << 6,

    /// <summary>
    ///     The attribute is used by the patchwork layout engine that draws the graph as a squarified treemap. The clusters of the graph
    ///     are used to specify the tree.
    /// </summary>
    Patchwork = 1 << 7,

    /// <summary>
    ///     The attribute is valid only when the PRoxImity Stress Model algorithm is in use.
    /// </summary>
    Prism = 1 << 8
}