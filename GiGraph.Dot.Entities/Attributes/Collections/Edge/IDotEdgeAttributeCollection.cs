namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public interface IDotEdgeAttributeCollection :
        IDotAttributeCollection,
        IDotEdgeAttributes,
        IDotEntityAttributeCollection<IDotEdgeAttributes>,
        IDotFillable
    {
    }
}