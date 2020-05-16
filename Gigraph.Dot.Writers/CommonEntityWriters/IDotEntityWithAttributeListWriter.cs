using Gigraph.Dot.Writers.AttributeWriters;

namespace Gigraph.Dot.Writers.CommonEntityWriters
{
    public interface IDotEntityWithAttributeListWriter : IDotEntityWriter
    {
        IDotAttributeStatementWriter BeginAttributeList(bool useAttributeSeparator);
        void EndAttributeList();
    }
}
