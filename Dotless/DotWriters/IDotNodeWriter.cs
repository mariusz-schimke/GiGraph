namespace Dotless.DotWriters
{
    public interface IDotNodeWriter : IDotWriter
    {
        void WriteNodeIdentifier(string id, bool quote);

        IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList();
    }
}