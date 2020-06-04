using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Writers.AttributeWriters
{
    public interface IDotAttributeListItemWriter : IDotEntityWriter
    {
        IDotAttributeWriter BeginAttribute();
        void EndAttribute();
    }
}