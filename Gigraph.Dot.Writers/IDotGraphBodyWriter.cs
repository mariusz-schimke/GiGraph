namespace Gigraph.Dot.Writers
{
    public interface IDotGraphBodyWriter : IDotEntityWriter
    {
        IDotAttributeCollectionWriter BeginAttributesSection(bool useStatementDelimiter);
        void EndAttributesSection(int attributeCount);

        IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter);
        void EndNodesSection(int nodeCount);

        IDotEdgeCollectionWriter BeginEdgesSection(bool useStatementDelimiter);
        void EndEdgesSection(int nodeCount);
    }
}