namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public interface IDotGraphAttributeCollection :
        IDotAttributeCollection,
        IDotGraphAttributes,
        IDotEntityAttributeCollection<IDotGraphAttributes>,
        IDotFillable
    {
    }
}