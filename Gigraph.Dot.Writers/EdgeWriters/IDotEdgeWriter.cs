using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.EdgeWriters
{
    public interface IDotEdgeWriter : IDotEntityWriter
    {
        void WriteEdge(string leftNodeId, bool quoteLeftNodeId, string rightNodeId, bool quoteRightNodeId);

        IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList(int attributeCount);
    }
}