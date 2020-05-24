using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Writers.EdgeWriters
{
    public interface IDotEdgeWriter : IDotEntityWithAttributeListWriter
    {
        void WriteNodeId(string nodeId, bool quoteNodeId);
        void WriteEdge();
    }
}