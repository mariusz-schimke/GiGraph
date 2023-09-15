using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Edges.Endpoints;

/// <summary>
///     Represents an endpoint of an edge.
/// </summary>
public abstract class DotEndpointDefinition : IDotEntity, IDotOrderable, IDotAnnotatable
{
    /// <inheritdoc cref="IDotAnnotatable.Annotation" />
    public virtual string Annotation { get; set; }

    string IDotOrderable.OrderingKey => GetOrderingKey();
    protected abstract string GetOrderingKey();

    public static implicit operator DotEndpointDefinition(string nodeId) => (DotEndpoint) nodeId;

    public static implicit operator DotEndpointDefinition(DotNode node) => (DotEndpoint) node;

    public static implicit operator DotEndpointDefinition(DotCluster cluster) => (DotClusterEndpoint) cluster;

    public static implicit operator DotEndpointDefinition(DotSubgraph subgraph) => (DotSubgraphEndpoint) subgraph;
}