namespace GiGraph.Dot.Output.Writers.Attributes.Graph
{
    public interface IDotGlobalGraphAttributeStatementWriter : IDotEntityWriter
    {
        IDotAttributeWriter BeginAttributeStatement();
        void EndAttributeStatement();
    }
}