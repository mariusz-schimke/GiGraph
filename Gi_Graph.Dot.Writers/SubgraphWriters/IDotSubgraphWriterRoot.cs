using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Writers.SubgraphWriters
{
    public interface IDotSubgraphWriterRoot : IDotEntityWriter
    {
        IDotSubgraphWriter BeginSubgraph(bool preferExplicitSubgraphKeyword);
        void EndSubgraph();
    }
}
