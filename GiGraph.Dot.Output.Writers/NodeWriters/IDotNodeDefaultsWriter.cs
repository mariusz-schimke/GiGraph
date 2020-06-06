using GiGraph.Dot.Output.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Output.Writers.NodeWriters
{
    public interface IDotNodeDefaultsWriter : IDotEntityWithAttributeListWriter
    {
        void WriteNodeKeyword();
    }
}