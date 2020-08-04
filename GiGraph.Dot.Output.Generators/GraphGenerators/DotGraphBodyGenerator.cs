using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Collections.Node;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Entities.Subgraphs.Collections;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.AttributeWriters;
using GiGraph.Dot.Output.Writers.EdgeWriters;
using GiGraph.Dot.Output.Writers.GlobalAttributesWriters;
using GiGraph.Dot.Output.Writers.GraphWriters;
using GiGraph.Dot.Output.Writers.NodeWriters;
using GiGraph.Dot.Output.Writers.SubgraphWriters;

namespace GiGraph.Dot.Output.Generators.GraphGenerators
{
    public class DotGraphBodyGenerator : DotEntityGenerator<DotCommonGraph, IDotGraphBodyWriter>
    {
        public DotGraphBodyGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotCommonGraph graphBody, IDotGraphBodyWriter writer)
        {
            // node and edge defaults have to appear first, so that they are applied to all elements that come later in the output script
            WriteGlobalAttributes(graphBody.Attributes, graphBody.NodeDefaults, graphBody.EdgeDefaults, writer);

            // subgraphs and clusters may also specify node defaults, and these are applied only
            // if the nodes they contain do not appear earlier in the parent graph or subgraph
            WriteSubgraphs(graphBody.Subgraphs, writer);
            WriteClusters(graphBody.Clusters, writer);

            // as already mentioned, nodes should not appear before subgraphs and clusters
            WriteNodes(graphBody.Nodes, writer);

            WriteEdges(graphBody.Edges, writer);
        }

        protected virtual void WriteGlobalAttributes(IDotAttributeCollection graphAttributes, IDotNodeAttributeCollection nodeDefaults, IDotEdgeAttributeCollection edgeDefaults, IDotGraphBodyWriter writer)
        {
            var writeGraphAttributes = graphAttributes.Any();

            // write graph attributes as a list of individual statements
            if (_options.Attributes.PreferGraphAttributesAsStatements)
            {
                WriteGraphAttributesAsStatementList(graphAttributes, writer);
                writeGraphAttributes = false;
            }

            if (!nodeDefaults.Any() && !edgeDefaults.Any() && !writeGraphAttributes)
            {
                return;
            }

            var globalAttributesWriter = writer.BeginGlobalAttributesSection(_options.PreferStatementDelimiter);

            if (writeGraphAttributes)
            {
                // write graph attributes as a "graph [attr_list]" clause
                WriteGraphAttributesAsClause(graphAttributes, globalAttributesWriter);
            }

            WriteNodeDefaults(nodeDefaults, globalAttributesWriter);
            WriteEdgeDefaults(edgeDefaults, globalAttributesWriter);

            writer.EndGlobalAttributesSection();
        }

        protected virtual void WriteGraphAttributesAsStatementList(IDotAttributeCollection attributes, IDotGraphBodyWriter writer)
        {
            if (attributes.Any())
            {
                var attributesWriter = writer.BeginAttributesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotAttributeStatementWriter>(attributes).Generate(attributes, attributesWriter);
                writer.EndAttributesSection();
            }
        }

        protected virtual void WriteGraphAttributesAsClause(IDotAttributeCollection attributes, IDotGlobalAttributesStatementWriter writer)
        {
            if (attributes.Any())
            {
                var attributesWriter = writer.BeginGraphAttributes();
                _entityGenerators.GetForEntity<IDotGraphAttributesWriter>(attributes).Generate(attributes, attributesWriter);
                writer.EndGraphAttributes();
            }
        }

        protected virtual void WriteNodeDefaults(IDotNodeAttributeCollection nodeDefaults, IDotGlobalAttributesStatementWriter writer)
        {
            if (nodeDefaults.Any())
            {
                var nodeDefaultsWriter = writer.BeginNodeDefaults();
                _entityGenerators.GetForEntity<IDotNodeDefaultsWriter>(nodeDefaults).Generate(nodeDefaults, nodeDefaultsWriter);
                writer.EndNodeDefaults();
            }
        }

        protected virtual void WriteEdgeDefaults(IDotEdgeAttributeCollection edgeDefaults, IDotGlobalAttributesStatementWriter writer)
        {
            if (edgeDefaults.Any())
            {
                var edgeDefaultsWriter = writer.BeginEdgeDefaults();
                _entityGenerators.GetForEntity<IDotEdgeDefaultsWriter>(edgeDefaults).Generate(edgeDefaults, edgeDefaultsWriter);
                writer.EndEdgeDefaults();
            }
        }

        protected virtual void WriteNodes(DotNodeCollection nodes, IDotGraphBodyWriter writer)
        {
            if (nodes.Any())
            {
                var nodeStatementWriter = writer.BeginNodesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotNodeStatementWriter>(nodes).Generate(nodes, nodeStatementWriter);
                writer.EndNodesSection();
            }
        }

        protected virtual void WriteEdges(DotEdgeCollection edges, IDotGraphBodyWriter writer)
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