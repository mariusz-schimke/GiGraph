using GiGraph.Dot.Entities;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
using GiGraph.Dot.Writers.CommonEntityWriters;
using System;

namespace GiGraph.Dot.Generators.CommonEntityGenerators
{
    public abstract class DotEntityGenerator<TEntity, TWriter> : IDotEntityGenerator<TEntity, TWriter>
        where TEntity : IDotEntity
        where TWriter : IDotEntityWriter
    {
        protected readonly DotSyntaxRules _syntaxRules;
        protected readonly DotGenerationOptions _options;
        protected readonly IDotEntityGeneratorsProvider _entityGenerators;
        protected readonly TextEscapingPipeline _identifierEscaper;

        public abstract void Generate(TEntity entity, TWriter writer);

        protected DotEntityGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
        {
            _syntaxRules = syntaxRules;
            _options = options;
            _entityGenerators = entityGenerators;
            _identifierEscaper = identifierEscaper ?? TextEscapingPipeline.Default();
        }

        public DotEntityGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : this(syntaxRules, options, entityGenerators, identifierEscaper: null)
        {
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
            return _identifierEscaper.Escape(id);
        }

        void IDotEntityGenerator.Generate(IDotEntity entity, IDotEntityWriter writer)
        {
            if (entity is { } && !(entity is TEntity))
            {
                throw new ArgumentException($"The entity type {entity.GetType().FullName} is not supported by the {GetType().FullName} generator.", nameof(entity));
            }

            if (!(writer is TWriter))
            {
                throw new ArgumentException($"The writer type {writer.GetType().FullName} is not valid for the {GetType().FullName} generator.", nameof(writer));
            }

            Generate((TEntity)entity, (TWriter)writer);
        }
    }
}
