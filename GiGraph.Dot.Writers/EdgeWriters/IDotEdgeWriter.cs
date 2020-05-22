using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Writers.EdgeWriters
{
    public interface IDotEdgeWriter : IDotEntityWithAttributeListWriter
    {
        void WriteEdge(string tailNodeId, bool quoteTailNodeId, string headNodeId, bool quoteHeadNodeId);
    }
}