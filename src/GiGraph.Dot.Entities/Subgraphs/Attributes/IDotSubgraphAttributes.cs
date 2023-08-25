using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Subgraphs.Attributes;

public interface IDotSubgraphAttributes
{
    /// <summary>
    ///     Gets or sets the rank constraints on the nodes in the subgraph (dot only).
    /// </summary>
    DotRank? NodeRank { get; set; }

    /// <summary>
    ///     <para>
    ///         Determines whether the subgraph is a cluster (default false). Subgraph clusters are rendered differently, e.g. dot
    ///         renders a box around subgraph clusters, but doesn't draw a box around non-subgraph clusters.
    ///     </para>
    ///     <para>
    ///         Since this library makes a strong distinction between subgraphs and clusters (in terms of what purpose they are used for
    ///         and what attributes are settable on each of them), you should use a <see cref="DotCluster" /> rather than a subgraph with
    ///         <see cref="IsCluster" /> set to <see langword="true" />.
    ///     </para>
    /// </summary>
    bool? IsCluster { get; set; }
}