using GiGraph.Dot.Entities.Attributes.Entities;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotGraphAttributeCollection :
        IDotAttributeCollection,
        IDotGraphAttributes,
        IDotEntityAttributeCollection<IDotGraphAttributes>,
        IDotFillable
    {
    }
}