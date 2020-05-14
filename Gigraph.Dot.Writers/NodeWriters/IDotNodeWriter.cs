using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public interface IDotNodeWriter : IDotEntityWriter
    {
        void WriteNodeIdentifier(string id, bool quote);

        IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList(int attributeCount);
    }
}