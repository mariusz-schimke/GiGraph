using GiGraph.Dot.Entities.Attributes.Entities;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotClusterAttributeCollection :
        IDotAttributeCollection,
        IDotClusterAttributes,
        IDotEntityAttributeCollection<IDotClusterAttributes>,
        IDotFillable
    {
    }
}