namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    /// <summary>
    /// Represents an endpoint of an edge.
    /// </summary>
    public abstract class DotEndpointDefinition : IDotOrderableEntity
    {
        string IDotOrderableEntity.OrderingKey => GetOrderingKey();
        protected abstract string GetOrderingKey();
    }
}
