using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.SubgraphWriters
{
    public interface IDotSubgraphWriterRoot : IDotEntityWriter
    {
        IDotSubgraphWriter BeginSubgraph(bool preferExplicitSubgraphKeyword);
        void EndSubgraph();
    }
}
