using Dotless.Core;

namespace Dotless.Attributes
{
    public interface IDotAttribute : IDotEntity
    {
        string Key { get; }
        bool HasValue { get; }

        // TODO: dodać GetStringValue()
    }

    // TODO: usunąć ten interfejs
    public interface IDotAttribute<T> : IDotAttribute
    {
        T Value { get; }
    }
}