namespace GiGraph.Dot.Output.Entities
{
    public interface IDotGraphSection : IDotEntity
    {
        IDotAttributeCollection Attributes { get; }
    }
}