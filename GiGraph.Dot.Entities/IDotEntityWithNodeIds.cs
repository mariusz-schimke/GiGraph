using System.Collections.Generic;

namespace GiGraph.Dot.Entities
{
    public interface IDotEntityWithNodeIds : IDotEntity
    {
        IEnumerable<string> NodeIds { get; }
    }
}
