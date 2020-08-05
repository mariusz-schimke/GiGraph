namespace GiGraph.Dot.Output.Writers.Attributes
{
    public interface IDotAttributeStatementWriter : IDotEntityWriter
    {
        IDotAttributeWriter BeginAttribute();
        void EndAttribute();
    }
}