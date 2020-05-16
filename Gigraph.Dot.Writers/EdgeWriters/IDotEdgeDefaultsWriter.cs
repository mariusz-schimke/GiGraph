using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.EdgeWriters
{
    public interface IDotEdgeDefaultsWriter : IDotEntityWithAttributeListWriter
    {
        void WriteEdgeKeyword();
    }
}