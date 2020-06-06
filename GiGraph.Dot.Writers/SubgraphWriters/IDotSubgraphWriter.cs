using GiGraph.Dot.Writers.GraphWriters;

namespace GiGraph.Dot.Writers.SubgraphWriters
{
    public interface IDotSubgraphWriter : IDotCommonGraphWriter
    {
        void WriteSubgraphDeclaration(string id, bool quoteId);
    }
}
