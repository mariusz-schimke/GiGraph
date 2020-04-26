using Dotless.Core;

namespace Dotless.Attributes
{
    public interface IAttribute : IEntity
    {
        string Key { get; }
        object? Value { get; }
    }

    public interface IAttribute<T> : IAttribute
    {
        new T Value { get; }
    }
}