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
    public virtual DotCluster Add(string id, Action<DotCluster>? init = null) => Add(new DotCluster(id), init);
}