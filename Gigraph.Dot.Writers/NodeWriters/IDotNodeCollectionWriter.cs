using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public interface IDotNodeCollectionWriter : IDotEntityWriter
    {
        IDotNodeWriter BeginNode();
        void EndNode();
    }
}
