using System.Collections.Generic;

namespace GiGraph.Dot.Output.Entities;

public interface IDotGraph : IDotEntity
{
    /// <summary>
    ///     Gets the identifier of the graph.
    /// </summary>
    string Id { get; }

    /// <summary>
    ///     Gets the subsections of the graph.
    /// </summary>
    IEnumerable<IDotGraphSection> Subsections { get; }
}