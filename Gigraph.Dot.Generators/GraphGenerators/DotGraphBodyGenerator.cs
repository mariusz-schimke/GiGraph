using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Entities.Nodes;
using Gigraph.Dot.Entities.Subgraphs;
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
    public class DotGraphBodyGenerator : DotEntityGenerator<DotGraphBody, IDotGraphBodyWriter>
    {
        public DotGraphBodyGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotGraphBody graphBody, IDotGraphBodyWriter writer)
        {
            WriteAttributes(graphBody.Attributes, writer);
            WriteNodes(graphBody.Nodes, writer);
            WriteEdges(graphBody.Edges, writer);
            WriteSubgraphs(graphBody.Subgraphs, writer);
        }

        protected virtual void WriteAttributes(DotAttributeCollection attributes, IDotGraphBodyWriter writer)
        {
            var attributesWriter = writer.BeginAttributesSection(_options.PreferStatementDelimiter);
            _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(attributes).Generate(attributes, attributesWriter);
            writer.EndAttributesSection(attributes.Count());
        }

        protected virtual void WriteNodes(DotNodeCollection nodes, IDotGraphBodyWriter writer)
        {
            var nodesWriter = writer.BeginNodesSection(_options.PreferStatementDelimiter);
            _entityGenerators.GetForEntity<IDotNodeCollectionWriter>(nodes).Generate(nodes, nodesWriter);
            writer.EndNodesSection(nodes.Count());
        }

        protected virtual void WriteEdges(DotEdgeCollection edges, IDotGraphBodyWriter writer)
        {
            var nodesWriter = writer.BeginEdgesSection(_options.PreferStatementDelimiter);
            _entityGenerators.GetForEntity<IDotEdgeCollectionWriter>(edges).Generate(edges, nodesWriter);
            writer.EndEdgesSection(edges.Count());
        }

        protected virtual void WriteSubgraphs(DotSubgraphCollection subgraphs, IDotGraphBodyWriter writer)
        {
            var subgraphsWriter = writer.BeginSubgraphsSection();
            _entityGenerators.GetForEntity<IDotSubgraphCollectionWriter>(subgraphs).Generate(subgraphs, subgraphsWriter);
            writer.EndSubgraphsSection(subgraphs.Count());
        }
    }
}
