using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public interface IDotNodeStatementWriter : IDotEntityWriter
    {
        IDotNodeWriter BeginNode();
        void EndNode();
    }
}
