namespace GiGraph.Dot.Output.Writers.Attributes
{
    public interface IDotAttributeListItemWriter : IDotEntityWriter
    {
        IDotAttributeWriter BeginAttribute();
        void EndAttribute();
    }
}