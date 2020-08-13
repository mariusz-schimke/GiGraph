using GiGraph.Dot.Output.Writers.Attributes;

namespace GiGraph.Dot.Output.Writers
{
    public interface IDotEntityWithAttributeListWriter : IDotEntityWriter
    {
        IDotAttributeListItemWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList();
    }
}