using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Writers.AttributeWriters
{
    public interface IDotAttributeStatementWriter : IDotEntityWriter
    {
        IDotAttributeWriter BeginAttribute();
        void EndAttribute();
    }
}