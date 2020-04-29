using Dotless.Core;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.Generators
{
    public interface IDotEntityGenerator
    {
        ICollection<IDotToken> Generate(IDotEntity entity);
    }

    public interface IEntityGenerator<T> : IDotEntityGenerator
        where T : IDotEntity
    {
        ICollection<IDotToken> Generate(T entity);
    }
}
