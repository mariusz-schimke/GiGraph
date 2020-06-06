using GiGraph.Dot.Writers.EdgeWriters;
using GiGraph.Dot.Writers.NodeWriters;

namespace GiGraph.Dot.Writers.EntityDefaultsWriters
{
    public interface IDotEntityDefaultsStatementWriter
    {
        IDotNodeDefaultsWriter BeginNodeDefaults();
        void EndNodeDefaults();

        IDotEdgeDefaultsWriter BeginEdgeDefaults();
        void EndEdgeDefaults();
    }
}
