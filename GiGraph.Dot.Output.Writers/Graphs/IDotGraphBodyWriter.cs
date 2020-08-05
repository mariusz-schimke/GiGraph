using GiGraph.Dot.Output.Writers.Attributes;
using GiGraph.Dot.Output.Writers.Edges;
using GiGraph.Dot.Output.Writers.Nodes;
using GiGraph.Dot.Output.Writers.Subgraphs;

namespace GiGraph.Dot.Output.Writers.Graphs
{
    public interface IDotGraphBodyWriter : IDotEntityWriter
    {
        IDotAttributeStatementWriter BeginAttributesSection(bool useStatementDelimiter);
        void EndAttributesSection();

        IDotGlobalAttributesStatementWriter BeginGlobalAttributesSection(bool useStatementDelimiter);
        void EndGlobalAttributesSection();

        IDotNodeStatementWriter BeginNodesSection(bool useStatementDelimiter);
        void EndNodesSection();

        IDotEdgeStatementWriter BeginEdgesSection(bool useStatementDelimiter);
        void EndEdgesSection();

        IDotSubgraphWriterRoot BeginSubgraphsSection();
        void EndSubgraphsSection();
    }
}