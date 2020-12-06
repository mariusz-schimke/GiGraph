using GiGraph.Dot.Entities.Subgraphs;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    /// <summary>
    ///     Represents an endpoint of an edge.
    /// </summary>
    public abstract class DotEndpointDefinition : IDotEntity, IDotOrderable, IDotAnnotatable
    {
        /// <inheritdoc cref="IDotAnnotatable.Annotation" />
        public virtual string Annotation { get; set; }

        string IDotOrderable.OrderingKey => GetOrderingKey();
        protected abstract string GetOrderingKey();

        public static implicit operator DotEndpointDefinition(string nodeId)
        {
            return (DotEndpoint) nodeId;
        }

        public static implicit operator DotEndpointDefinition(DotSubgraph subgraph)
        {
            return (DotSubgraphEndpoint) subgraph;
        }
    }
}