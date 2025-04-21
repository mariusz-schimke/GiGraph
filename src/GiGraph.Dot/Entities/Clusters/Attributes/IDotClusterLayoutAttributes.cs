using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Clusters.Attributes;

public interface IDotClusterLayoutAttributes
{
    /// <summary>
    ///     Gets or sets the sorting index of the cluster (default: 0). If <see cref="DotGraphLayoutAttributes.PackingMode"/> indicates
    ///     an array packing, this attribute specifies an insertion order among the components, with smaller values inserted first.
    /// </summary>
    int? SortIndex { get; set; }

    /// <summary>
    ///     Gets or sets the rank constraints on the nodes in the cluster (dot only).
    /// </summary>
    DotRank? NodeRank { get; set; }
}