using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Writers;

namespace GiGraph.Dot.Output.Generators;

/// <summary>
///     An entity generator that uses a writer to output an entity.
/// </summary>
/// <typeparam name="TWriter">
///     The writer type to be used by the generator to output the entity.
/// </typeparam>
public interface IDotEntityGenerator<in TWriter> : IDotEntityGenerator
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
    void Generate(IDotEntity entity, TWriter writer, bool annotate = true);
}