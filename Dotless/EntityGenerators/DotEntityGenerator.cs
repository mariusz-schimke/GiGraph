using Dotless.Core;
using Dotless.DotWriters;
using Dotless.EntityGenerators.Options;
using Dotless.TextEscaping;
using System;

namespace Dotless.EntityGenerators
{
    public abstract class DotEntityGenerator<TEntity, TWriter> : IDotEntityGenerator<TEntity, TWriter>
        where TEntity : IDotEntity
        where TWriter : IDotEntityWriter
    {
        protected readonly DotSyntaxRules _syntaxRules;
        protected readonly DotGenerationOptions _options;
        protected readonly DotEntityGeneratorsProvider _entityGenerators;
        protected readonly TextEscapingPipeline _valueEscaper = TextEscapingPipeline.CreateDefault();

        public abstract void Write(TEntity entity, TWriter writer);

        public DotEntityGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
        {
            _syntaxRules = syntaxRules;
            _options = options;
            _entityGenerators = entityGenerators;
        }

        public virtual bool Supports<TRequiredWriter>(Type entityType, out bool isExactEntityTypeMatch)
            where TRequiredWriter : IDotEntityWriter
        {
            isExactEntityTypeMatch = false;

            if (typeof(TRequiredWriter) != typeof(TWriter))
            {
                return false;
            }

            if (entityType == typeof(TEntity))
            {
                isExactEntityTypeMatch = true;
                return true;
            }

            return typeof(TEntity).IsAssignableFrom(entityType);
        }

        protected virtual bool IdentifierRequiresQuoting(string id)
        {
            return _options.PreferQuotedIdentifiers || !_syntaxRules.IsValidIdentifier(id);
        }

        protected virtual string? EscapeIdentifier(string? id)
        {
            return _valueEscaper.Escape(id);
        }

        void IDotEntityGenerator.Write(IDotEntity entity, IDotEntityWriter writer)
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
