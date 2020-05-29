namespace GiGraph.Dot.Entities
{
    public interface IDotOrderableEntity : IDotEntity
    {
        string OrderingKey { get; }
    }
}
