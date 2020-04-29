using Dotless.Core;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.Generators
{
    public interface IDotEntityGenerator
    {
        ICollection<IDotToken> Generate(IDotEntity entity, DotEntityGeneratorOptions options);
    }

    public interface IDotEntityGenerator<T> : IDotEntityGenerator
        where T : IDotEntity
    {
        ICollection<IDotToken> Generate(T entity, DotEntityGeneratorOptions options);
    }
}
