using System.Collections.Generic;

namespace GiGraph.Dot.Output.Entities
{
    public interface IDotGraph : IDotEntity
    {
        string Id { get; }
        IEnumerable<IDotGraphSection> Subsections { get; }
    }
}