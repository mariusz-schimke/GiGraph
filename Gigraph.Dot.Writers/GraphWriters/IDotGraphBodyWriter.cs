using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.CommonEntityWriters;
using Gigraph.Dot.Writers.EdgeWriters;
using Gigraph.Dot.Writers.EntityDefaultsWriter;
using Gigraph.Dot.Writers.NodeWriters;
using Gigraph.Dot.Writers.SubgraphWriters;

namespace Gigraph.Dot.Writers.GraphWriters
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