using GiGraph.Dot.Output.Writers.Edges;
using GiGraph.Dot.Output.Writers.Graphs;
using GiGraph.Dot.Output.Writers.Nodes;

namespace GiGraph.Dot.Output.Writers.Attributes
{
    public interface IDotGlobalAttributesStatementWriter
    {
        IDotGraphAttributesWriter BeginGraphAttributes();
        void EndGraphAttributes();

        IDotNodeDefaultsWriter BeginNodeDefaults();
        void EndNodeDefaults();

        IDotEdgeDefaultsWriter BeginEdgeDefaults();
        void EndEdgeDefaults();
    }
}