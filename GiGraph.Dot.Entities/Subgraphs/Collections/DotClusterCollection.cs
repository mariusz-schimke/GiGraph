using System;

namespace GiGraph.Dot.Entities.Subgraphs.Collections
{
    public class DotClusterCollection : DotCommonSubgraphCollection<DotCluster>
    {
        /// <summary>
        /// Adds a new cluster subgraph to the collection.
        /// </summary>
        /// <param name="init">An optional cluster initialization delegate.</param>
        public virtual DotCluster Add(Action<DotCluster> init = null)
        {
            return Add(id: null, init);
        }

        /// <summary>
        /// Adds a new cluster subgraph with the specified identifier to the collection.
        /// </summary>
        /// <param name="id">The unique identifier of the cluster. If no identifier is specified for multiple clusters added,
        /// they will be treated as one cluster when visualized.</param>
        /// <param name="init">An optional cluster initialization delegate.</param>
        public virtual DotCluster Add(string id, Action<DotCluster> init = null)
        {
            return Add(new DotCluster(id), init);
        }
    }
}
