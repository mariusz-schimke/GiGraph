using Dotless.Core;
using Dotless.DotWriters;
using Dotless.Writers.Options;

namespace Dotless.Writers
{
    public abstract class DotEntityWriter<TEntity> : IDotEntityWriter<TEntity>
        where TEntity : IDotEntity
    {
        protected readonly DotSyntaxRules _syntaxRules;
        protected readonly DotWriterOptions _options;
        protected readonly DotEntityWriterCollection _entityGenerators;

        // TODO: writer powinien być od razu konkretnego typu, rzutowany przez IDotEntityWriter.Write
        public abstract bool Write(TEntity entity, DotStringWriter writer);

        // TODO: zdecydować się co do nazwy - obecnie jest writers, a tu zostało generators
        public DotEntityWriter(DotSyntaxRules syntaxRules, DotWriterOptions options, DotEntityWriterCollection entityGenerators)
        {
            _syntaxRules = syntaxRules;
            _options = options;
            _entityGenerators = entityGenerators;
        }

        bool IDotEntityWriter.Write(IDotEntity entity, DotStringWriter writer)
        {
            return Write((TEntity)entity, writer);
        }
    }
}
