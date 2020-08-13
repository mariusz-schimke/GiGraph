using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The mode used for handling clusters.
    /// </summary>
    public enum DotClusterMode
    {
        /// <summary>
        ///     At present, the modes <see cref="Global" /> and <see cref="None" /> appear to be identical, both turning off the special
        ///     cluster processing, specific to the <see cref="Local" /> mode.
        /// </summary>
        [DotAttributeValue("none")]
        None,

        /// <summary>
        ///     At present, the modes <see cref="Global" /> and <see cref="None" /> appear to be identical, both turning off the special
        ///     cluster processing, specific to the <see cref="Local" /> mode.
        /// </summary>
        [DotAttributeValue("global")]
        Global,

        /// <summary>
        ///     When set, a subgraph whose name begins with "cluster" is given special treatment (refers to clusters added to the
        ///     <see cref="DotGraphSection{TGraphAttributes}.Clusters" /> collection of the root graph). The subgraph is laid out separately,
        ///     and then integrated as a unit into its parent graph, with a bounding rectangle drawn about it. If the cluster has a label
        ///     parameter, this label is displayed within the rectangle. Note also that there can be clusters within clusters.
        /// </summary>
        [DotAttributeValue("local")]
        Local
    }
}