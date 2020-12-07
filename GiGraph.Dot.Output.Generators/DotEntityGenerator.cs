using System;
using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Types.Identifiers;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers;

namespace GiGraph.Dot.Output.Generators
{
    public abstract class DotEntityGenerator<TEntity, TWriter> : IDotEntityGenerator<TWriter>
        where TEntity : IDotEntity, IDotAnnotatable
        where TWriter : IDotEntityWriter
    {
        protected readonly IDotEntityGeneratorsProvider _entityGenerators;
        protected readonly DotSyntaxOptions _options;
        protected readonly DotSyntaxRules _syntaxRules;

        protected DotEntityGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
        {
            _syntaxRules = syntaxRules;
            _options = options;
            _entityGenerators = entityGenerators;
        }

        /// <inheritdoc cref="IDotEntityGenerator.Supports{TWriter}" />
        public virtual bool Supports<TRequiredWriter>(IDotEntity entity, out bool isExactEntityTypeMatch)
            where TRequiredWriter : IDotEntityWriter
        {
            isExactEntityTypeMatch = false;

            if (typeof(TRequiredWriter) != typeof(TWriter))
            {
                return false;
            }

            if (!(entity is TEntity requiredEntityType))
            {
                return false;
            }

            isExactEntityTypeMatch = entity.GetType() == typeof(TEntity);
            return Supports(requiredEntityType);
        }

        /// <inheritdoc cref="IDotEntityGenerator{TWriter}.Generate" />
        public void Generate(IDotEntity entity, TWriter writer, bool annotate)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity must not be null.");
            }

            if (!(entity is TEntity actualEntity))
            {
                throw new ArgumentException($"The entity type {entity.GetType().FullName} is not supported by the {GetType().FullName} generator.", nameof(entity));
            }

            if (annotate)
            {
                WriteAnnotation(actualEntity, writer);
            }

            WriteEntity(actualEntity, writer);
        }

        protected virtual bool Supports(TEntity entity)
        {
            return true;
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

        protected virtual string EncodeIdentifier<TId>(TId id)
            where TId : DotId, IDotEncodable
        {
            return id.GetDotEncodedValue(_options, _syntaxRules);
        }

        protected virtual string EncodeIdentifier(string id)
        {
            return EncodeIdentifier(new DotId(id));
        }

        protected virtual bool IdentifierRequiresQuoting(string id)
        {
            return _options.PreferQuotedIdentifiers || !_syntaxRules.IsValidIdentifier(id);
        }
    }
}