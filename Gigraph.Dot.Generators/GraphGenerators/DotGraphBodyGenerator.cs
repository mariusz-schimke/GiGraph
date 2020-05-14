using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Entities.Nodes;
using Gigraph.Dot.Entities.Subgraphs;
using Gigraph.Dot.Generators.CommonEntityGenerators;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.CommonEntityWriters;
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
            WriteAttributes(graphBody.Attributes, writer);

            WriteDefaults(graphBody.NodeDefaults, graphBody.EdgeDefaults, writer);

            WriteNodes(graphBody.Nodes, writer);
            WriteEdges(graphBody.Edges, writer);

            WriteSubgraphs(graphBody.Subgraphs, writer);
        }

        protected virtual void WriteAttributes(DotAttributeCollection attributes, IDotGraphBodyWriter writer)
        {
            if (attributes.Any())
            {
                var attributesWriter = writer.BeginAttributesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(attributes).Generate(attributes, attributesWriter);
                writer.EndAttributesSection();
            }
        }

        private void WriteDefaults(DotNodeAttributeCollection nodeDefaults, DotEdgeAttributeCollection edgeDefaults, IDotGraphBodyWriter writer)
        {
            if (!nodeDefaults.Any() && !edgeDefaults.Any())
            {
                return;
            }

            writer.BeginDefaultsSection();

            WriteNodeDefaults(nodeDefaults, writer);
            WriteEdgeDefaults(edgeDefaults, writer);

            writer.EndDefaultsSection();
        }

        protected virtual void WriteNodeDefaults(DotNodeAttributeCollection nodeDefaults, IDotGraphBodyWriter writer)
        {
            if (nodeDefaults.Any())
            {
                var defaultsWriter = writer.BeginNodeDefaults();
                _entityGenerators.GetForEntity<IDotEntityDefaultsWriter>(nodeDefaults).Generate(nodeDefaults, defaultsWriter);
                writer.EndNodeDefaults(_options.PreferStatementDelimiter);
            }
        }

        protected virtual void WriteEdgeDefaults(DotEdgeAttributeCollection edgeDefaults, IDotGraphBodyWriter writer)
        {
            if (edgeDefaults.Any())
            {
                var defaultsWriter = writer.BeginEdgeDefaults();
                _entityGenerators.GetForEntity<IDotEntityDefaultsWriter>(edgeDefaults).Generate(edgeDefaults, defaultsWriter);
                writer.EndEdgeDefaults(_options.PreferStatementDelimiter);
            }
        }

        protected virtual void WriteNodes(DotNodeCollection nodes, IDotGraphBodyWriter writer)
        {
            if (nodes.Any())
            {
                var nodesWriter = writer.BeginNodesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotNodeCollectionWriter>(nodes).Generate(nodes, nodesWriter);
                writer.EndNodesSection();
            }
        }

        protected virtual void WriteEdges(DotEdgeCollection edges, IDotGraphBodyWriter writer)
        {
            if (edges.Any())
            {
                var nodesWriter = writer.BeginEdgesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotEdgeCollectionWriter>(edges).Generate(edges, nodesWriter);
                writer.EndEdgesSection();
            }
        }

        protected virtual void WriteSubgraphs(DotCommonSubgraphCollection subgraphs, IDotGraphBodyWriter writer)
        {
            if (subgraphs.Any())
            {
                var subgraphsWriter = writer.BeginSubgraphsSection();
                _entityGenerators.GetForEntity<IDotSubgraphCollectionWriter>(subgraphs).Generate(subgraphs, subgraphsWriter);
                writer.EndSubgraphsSection();
            }
        }
    }
}
