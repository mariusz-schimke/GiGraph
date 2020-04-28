using Dotless.Core;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.Generators
{
    public interface IEntityGenerator
    {
        ICollection<IToken> Generate(IEntity entity, GeneratorOptions options);
    }

    public interface IEntityGenerator<T> : IEntityGenerator
        where T : IEntity
    {
        ICollection<IToken> Generate(T entity, GeneratorOptions options);
    }
}
