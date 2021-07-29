namespace GiGraph.Dot.Output.Writers.Nodes
{
    public interface IDotNodeStatementWriter : IDotEntityWriter
    {
        IDotNodeWriter BeginNodeStatement();
        void EndNodeStatement();
    }
}