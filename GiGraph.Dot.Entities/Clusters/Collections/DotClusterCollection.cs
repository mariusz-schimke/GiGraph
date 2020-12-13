using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Graphs.Collections;

namespace GiGraph.Dot.Entities.Clusters.Collections
{
    public class DotClusterCollection : DotCommonGraphCollection<DotCluster>
    {
        /// <summary>
        ///     Adds a new cluster subgraph with the specified identifier to the collection.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier of the cluster. If no identifier or the same identifier is specified for multiple clusters added, they
        ///     will be treated as one cluster when visualized.
        /// </param>
        /// <param name="init">
        ///     An optional cluster initializer delegate.
        /// </param>
        public virtual DotCluster Add(string id, Action<DotCluster> init = null)
        {
            return AddCluster(id, nodeIds: Enumerable.Empty<string>(), init);
        }

        /// <summary>
        ///     Adds a new cluster subgraph with the specified identifier to the collection, and populates it with the specified nodes.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier of the cluster. If no identifier or the same identifier is specified for multiple clusters added, they
        ///     will be treated as one cluster when visualized.
        /// </param>
        /// <param name="nodeIds">
        ///     Optional node identifiers to populate the cluster with.
        /// </param>
        public virtual DotCluster Add(string id, params string[] nodeIds)
        {
            return AddCluster(id, nodeIds);
        }

        /// <summary>
        ///     Adds a new cluster subgraph with the specified identifier to the collection, and populates it with the specified nodes.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier of the cluster. If no identifier or the same identifier is specified for multiple clusters added, they
        ///     will be treated as one cluster when visualized.
        /// </param>
        /// <param name="nodeIds">
        ///     A node identifier collection to populate the cluster with.
        /// </param>
        public virtual DotCluster Add(string id, IEnumerable<string> nodeIds)
        {
            return AddCluster(id, nodeIds);
        }

        protected virtual DotCluster AddCluster(string id, IEnumerable<string> nodeIds, Action<DotCluster> init = null)
        {
            return Add(DotCluster.FromNodes(id, nodeIds), init);
        }
    }
}