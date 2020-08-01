using GiGraph.Dot.Entities.Attributes.Entities;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotEdgeAttributeCollection :
        IDotAttributeCollection,
        IDotEdgeAttributes,
        IDotEntityAttributeCollection<IDotEdgeAttributes>,
        IDotFillable
    {
    }
}