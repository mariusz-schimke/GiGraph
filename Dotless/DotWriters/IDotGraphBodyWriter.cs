namespace Dotless.DotWriters
{
    public interface IDotGraphBodyWriter : IDotWriter
    {
        IDotAttributeCollectionWriter BeginAttributesSection(bool preferExplicitAttributesSeparator);
        void EndAttributesSection();

        IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter);
        void EndNodesSection();
    }
}