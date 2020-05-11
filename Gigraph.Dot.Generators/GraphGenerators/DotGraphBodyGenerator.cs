using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.EdgeWriters;
using Gigraph.Dot.Writers.GraphWriters;
using Gigraph.Dot.Writers.NodeWriters;
using Gigraph.Dot.Writers.SubgraphWriters;
using System.Linq;

namespace Gigraph.Dot.Generators.GraphGenerators
{
    public class DotGraphBodyGenerator : DotEntityGenerator<DotCommonGraph, IDotGraphBodyWriter>
    {
        public DotGraphBodyGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonGraph graphBody, IDotGraphBodyWriter writer)
        {
            WriteAttributes(graphBody, writer);
            WriteNodes(graphBody, writer);
            WriteEdges(graphBody, writer);
            WriteSubgraphs(graphBody, writer);
        }

        protected virtual void WriteAttributes(DotCommonGraph graphBody, IDotGraphBodyWriter writer)
        {
            var attributesWriter = writer.BeginAttributesSection(_options.PreferStatementDelimiter);
            _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(graphBody.Attributes).Generate(graphBody.Attributes, attributesWriter);
            writer.EndAttributesSection(graphBody.Attributes.Count());
        }

        protected virtual void WriteNodes(DotCommonGraph graphBody, IDotGraphBodyWriter writer)
        {
            var nodesWriter = writer.BeginNodesSection(_options.PreferStatementDelimiter);
            _entityGenerators.GetForEntity<IDotNodeCollectionWriter>(graphBody.Nodes).Generate(graphBody.Nodes, nodesWriter);
            writer.EndNodesSection(graphBody.Nodes.Count());
        }

        protected virtual void WriteEdges(DotCommonGraph graphBody, IDotGraphBodyWriter writer)
        {
            var nodesWriter = writer.BeginEdgesSection(_options.PreferStatementDelimiter);
            _entityGenerators.GetForEntity<IDotEdgeCollectionWriter>(graphBody.Edges).Generate(graphBody.Edges, nodesWriter);
            writer.EndEdgesSection(graphBody.Edges.Count());
        }

        protected virtual void WriteSubgraphs(DotCommonGraph graphBody, IDotGraphBodyWriter writer)
        {
            var subgraphsWriter = writer.BeginSubgraphsSection();
            _entityGenerators.GetForEntity<IDotSubgraphCollectionWriter>(graphBody.Subgraphs).Generate(graphBody.Subgraphs, subgraphsWriter);
            writer.EndSubgraphsSection(graphBody.Subgraphs.Count());
        }
    }
}
