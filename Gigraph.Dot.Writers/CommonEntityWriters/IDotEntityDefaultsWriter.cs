using Gigraph.Dot.Writers.AttributeWriters;

namespace Gigraph.Dot.Writers.CommonEntityWriters
{
    public interface IDotEntityDefaultsWriter : IDotEntityWriter
    {
        void WriteEntityKeyword();

        IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList(int attributeCount);
    }
}