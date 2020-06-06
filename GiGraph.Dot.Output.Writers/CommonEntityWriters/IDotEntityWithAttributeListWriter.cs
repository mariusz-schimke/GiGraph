using GiGraph.Dot.Output.Writers.AttributeWriters;

namespace GiGraph.Dot.Output.Writers.CommonEntityWriters
{
    public interface IDotEntityWithAttributeListWriter : IDotEntityWriter
    {
        IDotAttributeListItemWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList();
    }
}