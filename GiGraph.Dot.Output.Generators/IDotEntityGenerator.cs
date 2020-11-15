using System;
using GiGraph.Dot.Entities;
using GiGraph.Dot.Output.Writers;

namespace GiGraph.Dot.Output.Generators
{
    public interface IDotEntityGenerator
    {
        /// <summary>
        ///     Determines whether the instance supports the specified entity type to generate.
        /// </summary>
        /// <param name="entityType">
        ///     The entity type to check.
        /// </param>
        /// <param name="isExactEntityTypeMatch">
        ///     Indicates if the specified entity type equals the type the current generator supports. If true is returned by the method,
        ///     false indicates that the type is still supported, but as a type compatible (e.g. a descendant) with the entity type supported
        ///     by the generator.
        /// </param>
        /// <typeparam name="TWriter">
        ///     The writer type that determines what type of entity of what part of an entity the generator is expected to support
        ///     generating.
        /// </typeparam>
        bool Supports<TWriter>(Type entityType, out bool isExactEntityTypeMatch) where TWriter : IDotEntityWriter;

        /// <summary>
        ///     Generates the specified entity using the specified writer.
        /// </summary>
        /// <param name="entity">
        ///     The entity to generate.
        /// </param>
        /// <param name="writer">
        ///     The instance to write the entity with.
        /// </param>
        /// <param name="annotate">
        ///     Determines whether the element should be annotated with a comment if available.
        /// </param>
        void Generate(IDotEntity entity, IDotEntityWriter writer, bool annotate = true);
    }

    /// <summary>
    ///     An entity generator that uses a writer to output an entity.
    /// </summary>
    /// <typeparam name="TEntity">
    ///     The entity type to be supported by the generator.
    /// </typeparam>
    /// <typeparam name="TWriter">
    ///     The writer type to be used by the generator to output the entity.
    /// </typeparam>
    public interface IDotEntityGenerator<in TEntity, in TWriter> : IDotEntityGenerator
        where TEntity : IDotEntity
        where TWriter : IDotEntityWriter
    {
        /// <summary>
        ///     Generates the specified entity using the specified writer.
        /// </summary>
        /// <param name="entity">
        ///     The entity to generate.
        /// </param>
        /// <param name="writer">
        ///     The instance to write the entity with.
        /// </param>
        /// <param name="annotate">
        ///     Determines whether the element should be annotated with a comment if available.
        /// </param>
        void Generate(TEntity entity, TWriter writer, bool annotate = true);
    }
}