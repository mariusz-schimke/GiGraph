using GiGraph.Dot.Entities.Graphs.Collections;

namespace GiGraph.Dot.Entities.Clusters.Collections;

public class DotClusterCollection : DotCommonGraphCollection<DotCluster>
{
    /// <summary>
    ///     Adds a new cluster subgraph with the specified identifier to the collection.
    /// </summary>
    /// <param name="id">
    ///     A unique identifier of the cluster. If no identifier or the same identifier is specified for multiple clusters having the
    ///     same parent, they are treated as one and the same cluster when visualized.
    /// </param>
    /// <param name="init">
    ///     An optional cluster initializer delegate.
    /// </param>
    public virtual DotCluster Add(string id, Action<DotCluster>? init = null) => AddCluster(id, nodeIds: [], init);

    /// <summary>
    ///     Adds a new cluster subgraph with the specified identifier to the collection, and populates it with the specified nodes.
    /// </summary>
    /// <param name="id">
    ///     A unique identifier of the cluster. If no identifier or the same identifier is specified for multiple clusters having the
    ///     same parent, they are treated as one and the same cluster when visualized.
    /// </param>
    /// <param name="nodeIds">
    ///     Optional node identifiers to populate the cluster with.
    /// </param>
    public virtual DotCluster AddWithNodes(string id, params string[] nodeIds) => AddCluster(id, nodeIds);

    /// <summary>
    ///     Adds a new cluster subgraph with the specified identifier to the collection, and populates it with the specified nodes.
    /// </summary>
    /// <param name="id">
    ///     The unique identifier of the cluster. If no identifier or the same identifier is specified for multiple clusters having the
    ///     same parent, they are treated as one and the same cluster when visualized.
    /// </param>
    /// <param name="nodeIds">
    ///     A node identifier collection to populate the cluster with.
    /// </param>
    public virtual DotCluster AddWithNodes(string id, IEnumerable<string> nodeIds) => AddCluster(id, nodeIds);

    protected virtual DotCluster AddCluster(string id, IEnumerable<string> nodeIds, Action<DotCluster>? init = null) =>
        Add(DotCluster.FromNodes(id, nodeIds), init);
}