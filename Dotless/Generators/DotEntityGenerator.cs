using Dotless.Core;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.Generators
{
    public abstract class DotEntityGenerator<TEntity> : IDotEntityGenerator<TEntity>
        where TEntity : IDotEntity
    {
        protected readonly DotSyntaxRules _syntaxRules;
        protected readonly DotEntityGeneratorCollection _entityGenerators;

        public abstract ICollection<IDotToken> Generate(TEntity entity, DotEntityGeneratorOptions options);

        public DotEntityGenerator(DotSyntaxRules syntaxRules, DotEntityGeneratorCollection entityGenerators)
        {
            _syntaxRules = syntaxRules;
            _entityGenerators = entityGenerators;
        }

        ICollection<IDotToken> IDotEntityGenerator.Generate(IDotEntity entity, DotEntityGeneratorOptions options)
        {
            return Generate((TEntity)entity, options);
        }
    }
}
