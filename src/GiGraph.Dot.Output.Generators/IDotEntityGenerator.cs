using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Writers;

namespace GiGraph.Dot.Output.Generators;

public interface IDotEntityGenerator
{
    /// <summary>
    ///     Determines whether the instance supports the specified entity type to generate.
    /// </summary>
    /// <param name="entity">
    ///     The entity to check.
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
    bool Supports<TWriter>(IDotEntity entity, out bool isExactEntityTypeMatch) where TWriter : IDotEntityWriter;
}