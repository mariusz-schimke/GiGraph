using GiGraph.Dot.Output.Writers.Graphs;

namespace GiGraph.Dot.Output.Writers.Subgraphs;

public interface IDotSubgraphWriter : IDotCommonGraphWriter
{
    void WriteSubgraphDeclaration(string id, bool quoteId);
}