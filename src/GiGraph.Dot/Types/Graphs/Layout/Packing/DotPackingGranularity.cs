using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Types.Graphs.Layout.Packing;

/// <summary>
///     Graph packing granularity options.
/// </summary>
public enum DotPackingGranularity
{
    /// <summary>
    ///     Causes packing at the node and edge level, with no overlapping of these objects. This produces a layout with the least area,
    ///     but it also allows interleaving, where a node of one component may lie between two nodes in another component.
    /// </summary>
    [DotAttributeValue("node")]
    Node,

    /// <summary>
    ///     Guarantees that top-level clusters are kept intact. What effect a value has also depends on the layout algorithm. For
    ///     example, neato does not support clusters, so a value of <see cref="Cluster"/> will have the same effect as the default "node"
    ///     value.
    /// </summary>
    [DotAttributeValue("clust")]
    Cluster,

    /// <summary>
    ///     Does a packing using the bounding box of the component. Thus, there will be a rectangular region around a component free of
    ///     elements of any other component.
    /// </summary>
    [DotAttributeValue("graph")]
    Graph
}