namespace GiGraph.Dot.Output.Writers.Subgraphs
{
    public interface IDotSubgraphWriterRoot : IDotEntityWriter
    {
        IDotSubgraphWriter BeginSubgraph(bool preferExplicitSubgraphKeyword);
        void EndSubgraph();
    }
}