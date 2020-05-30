namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    /// <summary>
    /// Represents an endpoint of an edge.
    /// </summary>
    public abstract class DotCommonEndpoint : IDotOrderableEntity
    {
        string IDotOrderableEntity.OrderingKey => GetOrderingKey();
        protected abstract string GetOrderingKey();
    }
}
