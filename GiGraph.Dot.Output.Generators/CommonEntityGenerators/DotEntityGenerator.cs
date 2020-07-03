using System;
using GiGraph.Dot.Entities;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Output.Generators.CommonEntityGenerators
{
    public abstract class DotEntityGenerator<TEntity, TWriter> : IDotEntityGenerator<TEntity, TWriter>
        where TEntity : IDotEntity, IDotAnnotatable
        where TWriter : IDotEntityWriter
    {
        protected readonly IDotEntityGeneratorsProvider _entityGenerators;
        protected readonly DotGenerationOptions _options;
        protected readonly DotSyntaxRules _syntaxRules;

        protected DotEntityGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
        {
            _syntaxRules = syntaxRules;
            _options = options;
            _entityGenerators = entityGenerators;
        }

        public void Generate(TEntity entity, TWriter writer, bool annotate)
        {
            if (annotate)
            {
                WriteAnnotation(entity, writer);
            }

            WriteEntity(entity, writer);
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

        void IDotEntityGenerator.Generate(IDotEntity entity, IDotEntityWriter writer, bool annotate)
        {
            if (entity is { } && !(entity is TEntity))
            {
                throw new ArgumentException($"The entity type {entity.GetType().FullName} is not supported by the {GetType().FullName} generator.", nameof(entity));
            }

            if (!(writer is TWriter))
            {
                throw new ArgumentException($"The writer type {writer.GetType().FullName} is not valid for the {GetType().FullName} generator.", nameof(writer));
            }

            Generate((TEntity) entity, (TWriter) writer, annotate);
        }

        protected abstract void WriteEntity(TEntity entity, TWriter writer);

        protected virtual void WriteAnnotation(TEntity entity, TWriter writer)
        {
            if (_options.Comments.Enabled && entity.Annotation is {})
            {
                var commentWriter = writer.BeginComment(_options.Comments.PreferBlockComments);
                commentWriter.Write(entity.Annotation);
                writer.EndComment();
            }
        }

        protected virtual string EscapeIdentifier(string id)
        {
            return _syntaxRules.EscapeIdentifier(id);
        }

        protected virtual bool IdentifierRequiresQuoting(string id)
        {
            return _options.PreferQuotedIdentifiers || !_syntaxRules.IsValidIdentifier(id);
        }
    }
}