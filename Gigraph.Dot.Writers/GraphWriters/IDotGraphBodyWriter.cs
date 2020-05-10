using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.EdgeWriters;
using Gigraph.Dot.Writers.NodeWriters;

namespace Gigraph.Dot.Writers.GraphWriters
{
    public interface IDotGraphBodyWriter : IDotEntityWriter
    {
        IDotAttributeCollectionWriter BeginAttributesSection(bool useStatementDelimiter);
        void EndAttributesSection(int attributeCount);

        IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter);
        void EndNodesSection(int nodeCount);

        IDotEdgeCollectionWriter BeginEdgesSection(bool useStatementDelimiter);
        void EndEdgesSection(int nodeCount);
    }
}