namespace Dotless.Generators
{
    public interface IEntityGenerator
    {
        string? Generate(object entity, GeneratorOptions options);
    }

    public interface IEntityGenerator<T> : IEntityGenerator
    {
        string? Generate(T entity, GeneratorOptions options)
        {
            return Generate(entity, options);
        }
    }
}
