using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Generators.CommonEntityGenerators;
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

            WriteDefaultNodeAttributes(graphBody, writer);
            WriteDefaultEdgeAttributes(graphBody, writer);

            WriteNodes(graphBody, writer);
            WriteEdges(graphBody, writer);

            WriteSubgraphs(graphBody, writer);
        }

        protected virtual void WriteAttributes(DotCommonGraph graphBody, IDotGraphBodyWriter writer)
        {
            var attributes = graphBody.Attributes;

            var attributesWriter = writer.BeginAttributesSection(_options.PreferStatementDelimiter);
            _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(attributes).Generate(attributes, attributesWriter);
            writer.EndAttributesSection(attributes.Count());
        }

        protected virtual void WriteDefaultNodeAttributes(DotCommonGraph graphBody, IDotGraphBodyWriter writer)
        {
            var attributes = graphBody.NodeDefaults;

            if (attributes.Any())
            {
                var attributesWriter = writer.BeginNodeDefaults();
                _entityGenerators.GetForEntity<IDotNodeDefaultsWriter>(attributes).Generate(attributes, attributesWriter);
                writer.EndNodeDefaults(_options.PreferStatementDelimiter);
            }
        }

        protected virtual void WriteDefaultEdgeAttributes(DotCommonGraph graphBody, IDotGraphBodyWriter writer)
        {
            var attributes = graphBody.EdgeDefaults;

            if (attributes.Any())
            {
                var attributesWriter = writer.BeginEdgeDefaults();
                _entityGenerators.GetForEntity<IDotEdgeDefaultsWriter>(attributes).Generate(attributes, attributesWriter);
                writer.EndEdgeDefaults(_options.PreferStatementDelimiter);
            }
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
