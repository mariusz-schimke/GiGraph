namespace Gigraph.Dot.Writers.SubgraphWriters
{
    public interface IDotSubgraphCollectionWriter : IDotEntityWriter
    {
        IDotSubgraphWriter BeginSubgraph(bool preferExplicitSubgraphKeyword);
        void EndSubgraph();
    }
}
