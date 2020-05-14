using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.EdgeWriters;
using Gigraph.Dot.Writers.NodeWriters;
using Gigraph.Dot.Writers.SubgraphWriters;

namespace Gigraph.Dot.Writers.GraphWriters
{
    public interface IDotGraphBodyWriter : IDotEntityWriter
    {
        IDotAttributeCollectionWriter BeginAttributesSection(bool useStatementDelimiter);
        void EndAttributesSection(int attributeCount);

        IDotNodeDefaultsWriter BeginNodeDefaults();
        void EndNodeDefaults(bool useStatementDelimiter);

        IDotEdgeDefaultsWriter BeginEdgeDefaults();
        void EndEdgeDefaults(bool useStatementDelimiter);

        IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter);
        void EndNodesSection(int nodeCount);

        IDotEdgeCollectionWriter BeginEdgesSection(bool useStatementDelimiter);
        void EndEdgesSection(int nodeCount);

        IDotSubgraphCollectionWriter BeginSubgraphsSection();
        void EndSubgraphsSection(int subgraphCount);
    }
}