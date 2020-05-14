using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.CommonEntityWriters;
using Gigraph.Dot.Writers.EdgeWriters;
using Gigraph.Dot.Writers.NodeWriters;
using Gigraph.Dot.Writers.SubgraphWriters;

namespace Gigraph.Dot.Writers.GraphWriters
{
    public interface IDotGraphBodyWriter : IDotEntityWriter
    {
        IDotAttributeCollectionWriter BeginAttributesSection(bool useStatementDelimiter);
        void EndAttributesSection();

        IDotEntityDefaultsWriter BeginNodeDefaults();
        void EndNodeDefaults(bool useStatementDelimiter);

        IDotEntityDefaultsWriter BeginEdgeDefaults();
        void EndEdgeDefaults(bool useStatementDelimiter);

        IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter);
        void EndNodesSection();

        IDotEdgeCollectionWriter BeginEdgesSection(bool useStatementDelimiter);
        void EndEdgesSection();

        IDotSubgraphCollectionWriter BeginSubgraphsSection();
        void EndSubgraphsSection();
    }
}