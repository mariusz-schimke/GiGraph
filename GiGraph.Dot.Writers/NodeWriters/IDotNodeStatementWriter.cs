using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Writers.NodeWriters
{
    public interface IDotNodeStatementWriter : IDotEntityWriter
    {
        IDotNodeWriter BeginNode();
        void EndNode();
    }
}
