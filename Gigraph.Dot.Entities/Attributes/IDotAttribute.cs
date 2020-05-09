namespace Gigraph.Dot.Entities.Attributes
{
    public interface IDotAttribute : IDotEntity
    {
        string Key { get; }
        string Value { get; }

        bool HasValue { get; }
    }
}