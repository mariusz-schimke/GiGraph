namespace Dotless.DotWriters
{
    public interface IDotEdgeWriter : IDotEntityWriter
    {
        void WriteEdge(bool directed, string leftNodeId, bool quoteLeftNodeId, string rightNodeId, bool quoteRightNodeId);

        IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList(int attributeCount);
    }
}