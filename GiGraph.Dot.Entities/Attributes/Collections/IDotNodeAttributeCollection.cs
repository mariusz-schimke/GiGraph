using GiGraph.Dot.Entities.Attributes.Entities;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotNodeAttributeCollection :
        IDotAttributeCollection,
        IDotNodeAttributes,
        IDotEntityAttributeCollection<IDotNodeAttributes>,
        IDotFillable
    {
    }
}