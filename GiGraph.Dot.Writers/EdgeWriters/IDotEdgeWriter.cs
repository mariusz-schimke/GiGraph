using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.SubgraphWriters;

namespace GiGraph.Dot.Writers.EdgeWriters
{
    public interface IDotEdgeWriter : IDotEntityWithAttributeListWriter
    {
        void WriteEndpoint(string nodeId, bool quoteNodeId, string portName, bool quotePortName, string compassPoint, bool quoteCompassPoint);

        IDotSubgraphWriter BeginSubgraph(bool preferExplicitKeyword);
        void EndSubgraph();
    }
}