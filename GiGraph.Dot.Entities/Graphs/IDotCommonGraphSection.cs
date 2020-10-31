using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Graphs
{
    public interface IDotCommonGraphSection : IDotEntity
    {
        DotAttributeCollection Attributes { get; }
    }
}