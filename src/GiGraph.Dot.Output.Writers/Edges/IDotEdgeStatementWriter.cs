namespace GiGraph.Dot.Output.Writers.Edges
{
    public interface IDotEdgeStatementWriter : IDotEntityWriter
    {
        IDotEdgeWriter BeginEdgeStatement(bool containsSubgraphs);
        void EndEdgeStatement();
    }
}