using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Writers.EdgeWriters
{
    public interface IDotEdgeStatementWriter : IDotEntityWriter
    {
        IDotEdgeWriter BeginEdge();
        void EndEdge();
    }
}
