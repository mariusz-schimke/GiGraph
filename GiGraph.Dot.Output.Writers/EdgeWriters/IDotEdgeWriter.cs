using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.SubgraphWriters;

namespace GiGraph.Dot.Output.Writers.EdgeWriters
{
    public interface IDotEdgeWriter : IDotEntityWithAttributeListWriter
    {
        IDotEndpointWriter BeginEndpoint();
        void EndEndpoint();

        IDotSubgraphWriter BeginSubgraph(bool preferExplicitKeyword);
        void EndSubgraph();

        void WriteEdge();
    }
}