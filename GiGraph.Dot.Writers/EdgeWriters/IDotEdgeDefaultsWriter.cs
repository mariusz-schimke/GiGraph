using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Writers.EdgeWriters
{
    public interface IDotEdgeDefaultsWriter : IDotEntityWithAttributeListWriter
    {
        void WriteEdgeKeyword();
    }
}