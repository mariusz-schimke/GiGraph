using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Graphs
{
    public interface IDotCommonGraph : IDotEntity
    {
        string Id { get; set; }
        IEnumerable<DotCommonGraphSection> Subsections { get; }
    }
}