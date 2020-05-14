using Gigraph.Dot.Writers.AttributeWriters;

namespace Gigraph.Dot.Writers.EdgeWriters
{
    public interface IDotEdgeDefaultsWriter : IDotEntityWriter
    {
        void WriteEdgeKeyword();

        IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList(int attributeCount);
    }
}