using Gigraph.Dot.Core;
using Gigraph.Dot.Core.TextEscaping;
using Gigraph.Dot.Entities;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers;
using System;

namespace Gigraph.Dot.Generators
{
    public abstract class DotEntityGenerator<TEntity, TWriter> : IDotEntityGenerator<TEntity, TWriter>
        where TEntity : IDotEntity
        where TWriter : IDotEntityWriter
    {
        protected readonly DotSyntaxRules _syntaxRules;
        protected readonly DotGenerationOptions _options;
        protected readonly IDotEntityGeneratorsProvider _entityGenerators;
        protected readonly TextEscapingPipeline _valueEscaper = TextEscapingPipeline.CreateDefault();

        public abstract void Generate(TEntity entity, TWriter writer);

        public DotEntityGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
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
            return id is { } && (_options.PreferQuotedIdentifiers || !_syntaxRules.IsValidIdentifier(id));
        }

        protected virtual string EscapeIdentifier(string id)
        {
            return _valueEscaper.Escape(id);
        }

        void IDotEntityGenerator.Generate(IDotEntity entity, IDotEntityWriter writer)
        {
            if (entity is { } && !(entity is TEntity))
            {
                throw new ArgumentException($"The entity type {entity.GetType().FullName} is not supported by the {GetType().FullName} generator.");
            }

            if (!(writer is TWriter))
            {
                throw new ArgumentException($"The writer type {writer.GetType().FullName} is not supported by the {GetType().FullName} generator.");
            }

            Generate((TEntity)entity, (TWriter)writer);
        }
    }
}
