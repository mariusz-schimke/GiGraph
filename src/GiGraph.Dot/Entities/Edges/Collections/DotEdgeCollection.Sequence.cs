using GiGraph.Dot.Entities.Edges.Endpoints;

namespace GiGraph.Dot.Entities.Edges.Collections;

public partial class DotEdgeCollection
{
    /// <summary>
    ///     Adds a sequence of edges that join specified nodes consecutively. At least a pair of identifiers has to be provided.
    /// </summary>
    /// <param name="nodeIds">
    ///     The identifiers of consecutive nodes to connect with edges (at least a pair is required).
    /// </param>
    /// <param name="init">
    ///     An optional initializer delegate to call for the created sequence.
    /// </param>
    public virtual DotEdgeSequence AddSequence(IEnumerable<string> nodeIds, Action<DotEdgeSequence>? init = null) =>
        Add(DotEdgeSequence.FromNodes(nodeIds), init);

    /// <summary>
    ///     Adds a sequence of edges that connect the specified endpoints consecutively. At least a pair of endpoints has to be provided.
    /// </summary>
    /// <param name="endpoints">
    ///     The endpoints to initialize the instance with (at least a pair is required).
    /// </param>
    /// <param name="init">
    ///     An optional initializer delegate to call for the created sequence.
    /// </param>
    public virtual DotEdgeSequence AddSequence(IEnumerable<DotEndpointDefinition> endpoints, Action<DotEdgeSequence>? init = null) =>
        Add(new DotEdgeSequence(endpoints), init);
}