using Gigraph.Dot.Writers.AttributeWriters;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public interface IDotNodeWriter : IDotEntityWriter
    {
        void WriteNodeIdentifier(string id, bool quote);

        IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList(int attributeCount);
    }
}