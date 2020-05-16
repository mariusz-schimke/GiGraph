using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.AttributeWriters
{
    public interface IDotAttributeStatementWriter : IDotEntityWriter
    {
        IDotAttributeWriter BeginAttribute();
        void EndAttribute();
    }
}