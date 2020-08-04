namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public interface IDotNodeAttributeCollection :
        IDotAttributeCollection,
        IDotNodeAttributes,
        IDotEntityAttributeCollection<IDotNodeAttributes>,
        IDotFillable
    {
    }
}