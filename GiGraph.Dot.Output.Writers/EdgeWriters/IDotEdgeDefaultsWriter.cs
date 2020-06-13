using GiGraph.Dot.Output.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Output.Writers.EdgeWriters
{
    public interface IDotEdgeDefaultsWriter : IDotEntityWithAttributeListWriter
    {
        void WriteEdgeKeyword();
    }
}