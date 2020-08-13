using GiGraph.Dot.Entities.Subgraphs;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    /// <summary>
    ///     Represents an endpoint of an edge.
    /// </summary>
    public abstract class DotEndpointDefinition : IDotOrderable
    {
        string IDotOrderable.OrderingKey => GetOrderingKey();
        protected abstract string GetOrderingKey();

        public static implicit operator DotEndpointDefinition(string nodeId)
        {
            return (DotEndpoint) nodeId;
        }

        public static implicit operator DotEndpointDefinition(string[] nodeIds)
        {
            return nodeIds is {} ? new DotEndpointGroup(nodeIds) : null;
        }

        public static implicit operator DotEndpointDefinition(DotSubgraph subgraph)
        {
            return subgraph is {} ? new DotEndpointGroup(subgraph) : null;
        }
    }
}