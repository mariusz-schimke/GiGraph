using Gigraph.Dot.Writers.AttributeWriters;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public interface IDotNodeDefaultsWriter : IDotEntityWriter
    {
        void WriteNodeKeyword();

        IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList(int attributeCount);
    }
}