using Gigraph.Dot.Writers.AttributeWriters;

namespace Gigraph.Dot.Writers.EdgeWriters
{
    public interface IDotEdgeWriter : IDotEntityWriter
    {
        void WriteEdge(string leftNodeId, bool quoteLeftNodeId, string rightNodeId, bool quoteRightNodeId);

        IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList(int attributeCount);
    }
}