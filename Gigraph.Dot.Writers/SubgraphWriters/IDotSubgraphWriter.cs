using Gigraph.Dot.Writers.GraphWriters;

namespace Gigraph.Dot.Writers.SubgraphWriters
{
    public interface IDotSubgraphWriter : IDotCommonGraphWriter
    {
        void WriteSubgraphDeclaration(string id, bool isCluster, bool quote);
    }
}
