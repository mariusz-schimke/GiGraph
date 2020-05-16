using Gigraph.Dot.Writers.EdgeWriters;
using Gigraph.Dot.Writers.NodeWriters;

namespace Gigraph.Dot.Writers.CommonEntityWriters
{
    public interface IDotEntityDefaultsStatementWriter
    {
        IDotNodeDefaultsWriter BeginNodeDefaults();
        void EndNodeDefaults();

        IDotEdgeDefaultsWriter BeginEdgeDefaults();
        void EndEdgeDefaults();
    }
}
