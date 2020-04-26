using Dotless.Core;

namespace Dotless.Generators
{
    public interface IEntityGenerator
    {
        string? Generate(IEntity entity, GeneratorOptions options);
    }

    public interface IEntityGenerator<T> : IEntityGenerator
        where T : IEntity
    {
        string? Generate(T entity, GeneratorOptions options);
    }
}
