using System;
using GiGraph.Dot.Entities;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Generators.Providers;

namespace GiGraph.Dot.Output.Generators.CommonEntityGenerators
{
    public abstract class DotEntityGenerator<TEntity, TWriter> : IDotEntityGenerator<TEntity, TWriter>
        where TEntity : IDotEntity
        where TWriter : IDotEntityWriter
    {
        protected readonly DotSyntaxRules _syntaxRules;
        protected readonly DotGenerationOptions _options;
        protected readonly IDotEntityGeneratorsProvider _entityGenerators;

        protected abstract void WriteEntity(TEntity entity, TWriter writer);

        public void Generate(TEntity entity, TWriter writer)
        {
            WriteNotesComment(entity, writer);
            WriteEntity(entity, writer);
        }

        protected DotEntityGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
        {
            _syntaxRules = syntaxRules;
            _options = options;
            _entityGenerators = entityGenerators;
        }

        protected virtual void WriteNotesComment(TEntity entity, TWriter writer)
        {
            if (entity.Notes is {})
            {
                var commentWriter = writer.BeginComment(_options.PreferBlockComments);
                commentWriter.Write(entity.Notes);
                writer.EndComment();
            }
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

            Generate((TEntity) entity, (TWriter) writer);
        }

        protected virtual string EscapeIdentifier(string id) => _syntaxRules.EscapeIdentifier(id);
        protected virtual bool IdentifierRequiresQuoting(string id) => _options.PreferQuotedIdentifiers || !_syntaxRules.IsValidIdentifier(id);
    }
}