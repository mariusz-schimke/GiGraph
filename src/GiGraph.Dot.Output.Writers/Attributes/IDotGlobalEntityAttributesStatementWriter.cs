using GiGraph.Dot.Output.Writers.Edges.Attributes;
using GiGraph.Dot.Output.Writers.Graphs.Attributes;
using GiGraph.Dot.Output.Writers.Nodes.Attributes;

namespace GiGraph.Dot.Output.Writers.Attributes
{
    public interface IDotGlobalEntityAttributesStatementWriter
    {
        IDotGlobalGraphAttributesWriter BeginGraphAttributesStatement();
        void EndGraphAttributesStatement();

        IDotGlobalNodeAttributesWriter BeginNodeAttributesStatement();
        void EndNodeAttributesStatement();

        IDotGlobalEdgeAttributesWriter BeginEdgeAttributesStatement();
        void EndEdgeAttributesStatement();
    }
}