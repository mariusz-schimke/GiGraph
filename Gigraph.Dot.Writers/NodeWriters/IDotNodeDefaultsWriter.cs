using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public interface IDotNodeDefaultsWriter : IDotEntityDefaultsWriter
    {
        void WriteNodeKeyword();
    }
}