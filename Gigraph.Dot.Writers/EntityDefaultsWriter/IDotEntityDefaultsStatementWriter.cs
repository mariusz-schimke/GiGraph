using Gigraph.Dot.Writers.EdgeWriters;
using Gigraph.Dot.Writers.NodeWriters;

namespace Gigraph.Dot.Writers.EntityDefaultsWriter
{
    public interface IDotEntityDefaultsStatementWriter
    {
        IDotNodeDefaultsWriter BeginNodeDefaults();
        void EndNodeDefaults();

        IDotEdgeDefaultsWriter BeginEdgeDefaults();
        void EndEdgeDefaults();
    }
}
