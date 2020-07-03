using GiGraph.Dot.Output.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Output.Writers.NodeWriters
{
    public interface IDotNodeStatementWriter : IDotEntityWriter
    {
        IDotNodeWriter BeginNode();
        void EndNode();
    }
}