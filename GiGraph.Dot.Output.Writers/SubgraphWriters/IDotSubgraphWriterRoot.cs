using GiGraph.Dot.Output.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Output.Writers.SubgraphWriters
{
    public interface IDotSubgraphWriterRoot : IDotEntityWriter
    {
        IDotSubgraphWriter BeginSubgraph(bool preferExplicitSubgraphKeyword);
        void EndSubgraph();
    }
}