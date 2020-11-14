using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Graphs
{
    public interface IDotCommonGraph : IDotEntity
    {
        /// <summary>
        ///     Gets the identifier of the graph.
        /// </summary>
        string Id { get; }

        /// <summary>
        ///     Gets the subsections of the graph.
        /// </summary>
        IEnumerable<DotCommonGraphSection> Subsections { get; }
    }
}