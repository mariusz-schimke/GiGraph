using GiGraph.Dot.Output.Writers.Attributes;
using GiGraph.Dot.Output.Writers.Attributes.Graph;
using GiGraph.Dot.Output.Writers.Edges;
using GiGraph.Dot.Output.Writers.Nodes;
using GiGraph.Dot.Output.Writers.Subgraphs;

namespace GiGraph.Dot.Output.Writers.Graphs
{
    public interface IDotGraphBodyWriter : IDotEntityWriter
    {
        IDotGlobalGraphAttributeStatementWriter BeginGlobalGraphAttributesSection(bool useStatementDelimiter);
        void EndGlobalGraphAttributesSection();

        IDotGlobalEntityAttributesStatementWriter BeginGlobalEntityAttributesSection(bool useStatementDelimiter);
        void EndGlobalEntityAttributesSection();

        IDotNodeStatementWriter BeginNodesSection(bool useStatementDelimiter);
        void EndNodesSection();

        IDotEdgeStatementWriter BeginEdgesSection(bool useStatementDelimiter);
        void EndEdgesSection();

        IDotSubgraphWriterRoot BeginSubgraphsSection();
        void EndSubgraphsSection();

        IDotSubgraphWriterRoot BeginClustersSection();
        void EndClustersSection();
    }
}