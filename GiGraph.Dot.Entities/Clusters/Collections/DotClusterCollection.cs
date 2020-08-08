using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Subgraphs.Collections;

namespace GiGraph.Dot.Entities.Clusters.Collections
{
    public class DotClusterCollection : DotCommonSubgraphCollection<DotCluster>
    {
        /// <summary>
        ///     Adds a new cluster subgraph with the specified identifier to the collection.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier of the cluster. If no identifier or the same identifier is specified for multiple clusters added, they
        ///     will be treated as one cluster when visualized.
        /// </param>
        /// <param name="init">
        ///     An optional cluster initialization delegate.
        /// </param>
        public virtual DotCluster Add(string id, Action<DotCluster> init = null)
        {
            return AddCluster(id, nodeIds: Enumerable.Empty<string>(), init);
        }

        /// <summary>
        ///     Adds a new cluster subgraph with the specified identifier and nodes to the collection.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier of the cluster. If no identifier or the same identifier is specified for multiple clusters added, they
        ///     will be treated as one cluster when visualized.
        /// </param>
        /// <param name="nodeIds">
        ///     Optional node identifiers to initialize the cluster with.
        /// </param>
        public virtual DotCluster Add(string id, params string[] nodeIds)
        {
            return AddCluster(id, nodeIds, init: null);
        }

        /// <summary>
        ///     Adds a new cluster subgraph with the specified identifier and nodes to the collection.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier of the cluster. If no identifier or the same identifier is specified for multiple clusters added, they
        ///     will be treated as one cluster when visualized.
        /// </param>
        /// <param name="nodeIds">
        ///     Optional node identifiers to initialize the cluster with.
        /// </param>
        /// <param name="init">
        ///     An optional cluster initialization delegate.
        /// </param>
        public virtual DotCluster Add(string id, Action<DotCluster> init, params string[] nodeIds)
        {
            return AddCluster(id, nodeIds, init);
        }

        /// <summary>
        ///     Adds a new cluster subgraph with the specified identifier and nodes to the collection.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier of the cluster. If no identifier or the same identifier is specified for multiple clusters added, they
        ///     will be treated as one cluster when visualized.
        /// </param>
        /// <param name="nodeIds">
        ///     A node identifier collection to initialize the cluster with.
        /// </param>
        /// <param name="init">
        ///     An optional cluster initialization delegate.
        /// </param>
        public virtual DotCluster Add(string id, IEnumerable<string> nodeIds, Action<DotCluster> init = null)
        {
            return AddCluster(id, nodeIds, init);
        }

        protected virtual DotCluster AddCluster(string id, IEnumerable<string> nodeIds, Action<DotCluster> init)
        {
            return Add(DotCluster.FromNodes(id, nodeIds), init);
        }
    }
}