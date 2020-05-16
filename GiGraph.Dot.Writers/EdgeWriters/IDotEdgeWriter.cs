using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Writers.EdgeWriters
{
    public interface IDotEdgeWriter : IDotEntityWithAttributeListWriter
    {
        void WriteEdge(string leftNodeId, bool quoteLeftNodeId, string rightNodeId, bool quoteRightNodeId);
    }
}