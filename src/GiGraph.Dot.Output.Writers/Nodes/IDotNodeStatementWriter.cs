namespace GiGraph.Dot.Output.Writers.Nodes
{
    public interface IDotNodeStatementWriter : IDotEntityWriter
    {
        IDotNodeWriter BeginNodeStatement(bool containsAttributes);
        void EndNodeStatement();
    }
}