using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Subgraphs.Attributes;

public interface IDotSubgraphAttributes
{
    /// <summary>
    ///     Gets or sets the rank constraints on the nodes in the subgraph (dot only).
    /// </summary>
    DotRankAlignment? NodeRankAlignment { get; set; }

    /// <summary>
    ///     <para>
    ///         Determines whether the subgraph is a cluster (default false). Subgraph clusters are rendered differently, e.g. dot
    ///         renders a box around subgraph clusters, but doesn't draw a box around non-subgraph clusters.
    ///     </para>
    ///     <para>
    ///         Note: This library treats subgraphs and clusters as conceptually different types, with different intended uses and
    ///         different sets of attributes. So if you're setting <see cref="IsCluster"/> to <see langword="true"/>, it's usually better
    ///         to use a <see cref="DotCluster"/> instead of a <see cref="DotSubgraph"/>.
    ///     </para>
    /// </summary>
    bool? IsCluster { get; set; }
}