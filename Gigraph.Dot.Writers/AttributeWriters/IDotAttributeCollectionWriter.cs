using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.AttributeWriters
{
    public interface IDotAttributeCollectionWriter : IDotEntityWriter
    {
        IDotAttributeWriter BeginAttribute();
        void EndAttribute();
    }
}