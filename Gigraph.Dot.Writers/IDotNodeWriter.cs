namespace Gigraph.Dot.Writers
{
    public interface IDotNodeWriter : IDotEntityWriter
    {
        void WriteNodeIdentifier(string id, bool quote);

        IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList(int attributeCount);
    }
}