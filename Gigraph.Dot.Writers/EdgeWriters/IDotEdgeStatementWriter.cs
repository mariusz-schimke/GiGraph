using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.EdgeWriters
{
    public interface IDotEdgeStatementWriter : IDotEntityWriter
    {
        IDotEdgeWriter BeginEdge();
        void EndEdge();
    }
}
