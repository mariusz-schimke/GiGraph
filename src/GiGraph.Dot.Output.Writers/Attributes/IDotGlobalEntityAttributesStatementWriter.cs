using GiGraph.Dot.Output.Writers.Attributes.Edge;
using GiGraph.Dot.Output.Writers.Attributes.Graph;
using GiGraph.Dot.Output.Writers.Attributes.Node;

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