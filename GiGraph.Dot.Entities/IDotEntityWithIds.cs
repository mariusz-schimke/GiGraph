using System.Collections.Generic;

namespace GiGraph.Dot.Entities
{
    public interface IDotEntityWithIds : IDotEntity
    {
        IEnumerable<string> Ids { get; }
    }
}
