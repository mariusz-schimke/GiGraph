using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.EdgeWriters
{
    public interface IDotEdgeWriter : IDotEntityWithAttributeListWriter
    {
        void WriteEdge(string leftNodeId, bool quoteLeftNodeId, string rightNodeId, bool quoteRightNodeId);
    }
}