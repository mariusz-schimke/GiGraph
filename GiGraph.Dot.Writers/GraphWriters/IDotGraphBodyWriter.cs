using GiGraph.Dot.Writers.AttributeWriters;
using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.EdgeWriters;
using GiGraph.Dot.Writers.EntityDefaultsWriter;
using GiGraph.Dot.Writers.NodeWriters;
using GiGraph.Dot.Writers.SubgraphWriters;

namespace GiGraph.Dot.Writers.GraphWriters
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