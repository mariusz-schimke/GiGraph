using Gigraph.Dot.Writers.AttributeWriters;

namespace Gigraph.Dot.Writers.CommonEntityWriters
{
    public interface IDotEntityWithAttributesWriter : IDotEntityWriter
    {
        IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList(int attributeCount);
    }
}
