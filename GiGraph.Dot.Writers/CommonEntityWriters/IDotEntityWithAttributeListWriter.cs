using GiGraph.Dot.Writers.AttributeWriters;

namespace GiGraph.Dot.Writers.CommonEntityWriters
{
    public interface IDotEntityWithAttributeListWriter : IDotEntityWriter
    {
        IDotAttributeStatementWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList();
    }
}
