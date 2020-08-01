using GiGraph.Dot.Entities.Attributes.Entities;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotSubgraphAttributeCollection :
        IDotAttributeCollection,
        IDotSubgraphAttributes,
        IDotEntityAttributeCollection<IDotSubgraphAttributes>
    {
    }
}