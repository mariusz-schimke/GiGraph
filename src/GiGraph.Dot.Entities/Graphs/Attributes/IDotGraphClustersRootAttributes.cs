using GiGraph.Dot.Entities.Clusters.Attributes;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public interface IDotGraphClustersRootAttributes : IDotGraphClustersAttributes
    {
        /// <summary>
        ///     Style options. Note that the options are shared with those of the graph.
        /// </summary>
        DotClusterStyleAttributeOptions Style { get; }
    }
}