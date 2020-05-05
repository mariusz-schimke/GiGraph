namespace Dotless.DotWriters
{
    public interface IDotGraphBodyWriter : IDotEntityWriter
    {
        IDotAttributeCollectionWriter BeginAttributesSection(bool useStatementDelimiter);
        void EndAttributesSection();

        IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter);
        void EndNodesSection();
    }
}