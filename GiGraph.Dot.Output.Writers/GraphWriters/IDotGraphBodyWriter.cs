using GiGraph.Dot.Output.Writers.AttributeWriters;
using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.EdgeWriters;
using GiGraph.Dot.Output.Writers.EntityDefaultsWriters;
using GiGraph.Dot.Output.Writers.NodeWriters;
using GiGraph.Dot.Output.Writers.SubgraphWriters;

namespace GiGraph.Dot.Output.Writers.GraphWriters
{
    public interface IDotGraphBodyWriter : IDotEntityWriter
    {
        IDotAttributeStatementWriter BeginAttributesSection(bool useStatementDelimiter);
        void EndAttributesSection();

        IDotEntityDefaultsStatementWriter BeginDefaultsSection(bool useStatementDelimiter);
        void EndDefaultsSection();

        IDotNodeStatementWriter BeginNodesSection(bool useStatementDelimiter);
        void EndNodesSection();

        IDotEdgeStatementWriter BeginEdgesSection(bool useStatementDelimiter);
        void EndEdgesSection();

        IDotSubgraphWriterRoot BeginSubgraphsSection();
        void EndSubgraphsSection();
    }
}