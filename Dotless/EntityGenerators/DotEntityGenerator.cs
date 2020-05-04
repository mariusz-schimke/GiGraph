using Dotless.Core;
using Dotless.DotWriters;
using Dotless.EntityGenerators.Options;
using System;

namespace Dotless.EntityGenerators
{
    public abstract class DotEntityGenerator<TEntity, TWriter> : IDotEntityGenerator<TEntity, TWriter>
        where TEntity : IDotEntity
        where TWriter : IDotWriter
    {
        protected readonly DotSyntaxRules _syntaxRules;
        protected readonly DotGenerationOptions _options;
        protected readonly DotEntityGeneratorsProvider _entityGenerators;

        // TODO: writer powinien być od razu konkretnego typu, rzutowany przez IDotEntityWriter.Write
        public abstract void Write(TEntity entity, TWriter writer);

        // TODO: zdecydować się co do nazwy - obecnie jest writers, a tu zostało generators
        public DotEntityGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
        {
            _syntaxRules = syntaxRules;
            _options = options;
            _entityGenerators = entityGenerators;
        }

        public virtual bool Supports<TRequiredWriter>(Type entityType, bool exactEntityTypeMatching = false)
            where TRequiredWriter : IDotWriter
        {
            if (typeof(TRequiredWriter) != typeof(TWriter))
            {
                return false;
            }

            if (entityType == typeof(TEntity))
            {
                return true;
            }

            if (!exactEntityTypeMatching)
            {
                return typeof(TEntity).IsAssignableFrom(entityType);
            }

            return false;
        }

        protected virtual bool IdRequiresQuoting(string id)
        {
            return _options.PreferQuotedIdentifiers || !_syntaxRules.IsValidIdentifier(id);
        }

        void IDotEntityGenerator.Write(IDotEntity entity, IDotWriter writer)
        {
            if (entity is { } && !(entity is TEntity))
            {
                throw new ArgumentException($"The entity type {entity.GetType().FullName} is not supported by the {GetType().FullName} generator.");
            }

            if (!(writer is TWriter))
            {
                throw new ArgumentException($"The writer type {writer.GetType().FullName} is not supported by the {GetType().FullName} generator.");
            }

            Write((TEntity)entity!, (TWriter)writer);
        }
    }
}
