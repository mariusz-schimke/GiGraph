using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Entities.Subgraphs.Collections;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.AttributeWriters;
using GiGraph.Dot.Output.Writers.EdgeWriters;
using GiGraph.Dot.Output.Writers.GraphWriters;
using GiGraph.Dot.Output.Writers.NodeWriters;
using GiGraph.Dot.Output.Writers.SubgraphWriters;
using System.Linq;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.TextEscaping;
using GiGraph.Dot.Output.Writers.GlobalAttributesWriters;

namespace GiGraph.Dot.Output.Generators.GraphGenerators
{
    public class DotGraphBodyGenerator : DotEntityGenerator<DotCommonGraph, IDotGraphBodyWriter>
    {
        protected DotGraphBodyGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, IDotTextEscaper identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotGraphBodyGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonGraph graphBody, IDotGraphBodyWriter writer)
        {
            WriteAttributes(graphBody.Attributes, writer);

            // the defaults have to appear first, so that they are applied to all elements that come later in the output script
            WriteDefaults(graphBody.NodeDefaults, graphBody.EdgeDefaults, writer);

            // subgraphs and clusters may also specify node defaults, and these are applied only
            // if the nodes they contain do not appear earlier in the parent graph or subgraph
            WriteSubgraphs(graphBody.Subgraphs, writer);
            WriteClusters(graphBody.Clusters, writer);

            // as already mentioned, nodes should not appear before subgraphs and clusters
            WriteNodes(graphBody.Nodes, writer);

            WriteEdges(graphBody.Edges, writer);
        }

        protected virtual void WriteAttributes(IDotAttributeCollection attributes, IDotGraphBodyWriter writer)
        {
            if (attributes.Any())
            {
                var attributesWriter = writer.BeginAttributesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotAttributeStatementWriter>(attributes).Generate(attributes, attributesWriter);
                writer.EndAttributesSection();
            }
        }

        private void WriteDefaults(IDotNodeAttributes nodeDefaults, IDotEdgeAttributes edgeDefaults, IDotGraphBodyWriter writer)
        {
            if (!nodeDefaults.Any() && !edgeDefaults.Any())
            {
                return;
            }

            var globalAttributesWriter = writer.BeginGlobalAttributesSection(_options.PreferStatementDelimiter);

            WriteNodeDefaults(nodeDefaults, globalAttributesWriter);
            WriteEdgeDefaults(edgeDefaults, globalAttributesWriter);

            writer.EndGlobalAttributesSection();
        }

        protected virtual void WriteNodeDefaults(IDotNodeAttributes nodeDefaults, IDotGlobalAttributesStatementWriter writer)
        {
            if (nodeDefaults.Any())
            {
                var nodeDefaultsWriter = writer.BeginNodeDefaults();
                _entityGenerators.GetForEntity<IDotNodeDefaultsWriter>(nodeDefaults).Generate(nodeDefaults, nodeDefaultsWriter);
                writer.EndNodeDefaults();
            }
        }

        protected virtual void WriteEdgeDefaults(IDotEdgeAttributes edgeDefaults, IDotGlobalAttributesStatementWriter writer)
        {
            if (edgeDefaults.Any())
            {
                var edgeDefaultsWriter = writer.BeginEdgeDefaults();
                _entityGenerators.GetForEntity<IDotEdgeDefaultsWriter>(edgeDefaults).Generate(edgeDefaults, edgeDefaultsWriter);
                writer.EndEdgeDefaults();
            }
        }

        protected virtual void WriteNodes(DotCommonNodeCollection nodes, IDotGraphBodyWriter writer)
        {
            if (nodes.Any())
            {
                var nodeStatementWriter = writer.BeginNodesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotNodeStatementWriter>(nodes).Generate(nodes, nodeStatementWriter);
                writer.EndNodesSection();
            }
        }

        protected virtual void WriteEdges(DotCommonEdgeCollection edges, IDotGraphBodyWriter writer)
        {
            if (edges.Any())
            {
                var edgeStatementWriter = writer.BeginEdgesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotEdgeStatementWriter>(edges).Generate(edges, edgeStatementWriter);
                writer.EndEdgesSection();
            }
        }

        protected virtual void WriteSubgraphs(DotSubgraphCollection subgraphs, IDotGraphBodyWriter writer)
        {
            WriteCommonSubgraphs(subgraphs, writer);
        }

        protected virtual void WriteClusters(DotClusterCollection clusters, IDotGraphBodyWriter writer)
        {
            WriteCommonSubgraphs(clusters, writer);
        }

        protected virtual void WriteCommonSubgraphs<T>(DotCommonSubgraphCollection<T> subgraphs, IDotGraphBodyWriter writer)
            where T : DotCommonSubgraph
        {
            if (subgraphs.Any())
            {
                var subgraphWriterRoot = writer.BeginSubgraphsSection();
                _entityGenerators.GetForEntity<IDotSubgraphWriterRoot>(subgraphs).Generate(subgraphs, subgraphWriterRoot);
                writer.EndSubgraphsSection();
            }
        }
    }
}
