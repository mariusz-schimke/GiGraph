using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Writers.NodeWriters
{
    public interface IDotNodeDefaultsWriter : IDotEntityWithAttributeListWriter
    {
        void WriteNodeKeyword();
    }
}