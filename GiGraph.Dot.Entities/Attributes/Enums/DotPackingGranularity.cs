using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
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
        ///     example, neato does not support clusters, so a value of <see cref="Cluster" /> will have the same e"ect as the default "node"
        ///     value.
        /// </summary>
        [DotAttributeValue("clust")]
        Cluster,

        /// <summary>
        ///     Does a packing using the bounding box of the component. Thus, there will be a rectangular region around a component free of
        ///     elements of any other component.
        /// </summary>
        [DotAttributeValue("graph")]
        Graph,

        /// <summary>
        ///     Indicates that the components should be packed at the graph level into an array of graphs. By default, the components are in
        ///     row-major order, with the number of columns roughly the square root of the number of components.
        /// </summary>
        [DotAttributeValue("array")]
        Array
    }
}