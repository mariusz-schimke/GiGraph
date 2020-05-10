using Gigraph.Dot.Writers.GraphWriters;

namespace Gigraph.Dot.Writers.SubgraphWriters
{
    public interface IDotSubgraphWriter : IDotEntityWriter
    {
        void WriteSubgraphDeclaration(string id, bool quote);

        IDotGraphBodyWriter BeginBody();
        void EndBody();
    }
}
