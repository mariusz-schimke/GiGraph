namespace Dotless.DotWriters
{
    public interface IDotGraphBodyWriter : IDotEntityWriter
    {
        IDotAttributeCollectionWriter BeginAttributesSection(bool useStatementDelimiter);
        void EndAttributesSection(int attributeCount);

        IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter);
        void EndNodesSection(int nodeCount);
    }
}