using GiGraph.Dot.Output.Writers.GraphWriters;

namespace GiGraph.Dot.Output.Writers.SubgraphWriters
{
    public interface IDotSubgraphWriter : IDotCommonGraphWriter
    {
        void WriteSubgraphDeclaration(string id, bool quoteId);
    }
}
