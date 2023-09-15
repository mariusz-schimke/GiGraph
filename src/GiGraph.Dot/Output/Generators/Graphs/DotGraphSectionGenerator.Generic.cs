using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Attributes;
using GiGraph.Dot.Output.Writers.Edges;
using GiGraph.Dot.Output.Writers.Edges.Attributes;
using GiGraph.Dot.Output.Writers.Graphs;
using GiGraph.Dot.Output.Writers.Graphs.Attributes;
using GiGraph.Dot.Output.Writers.Nodes;
using GiGraph.Dot.Output.Writers.Nodes.Attributes;
using GiGraph.Dot.Output.Writers.Subgraphs;

namespace GiGraph.Dot.Output.Generators.Graphs;

public abstract class DotGraphSectionGenerator<TSection> : DotEntityGenerator<TSection, IDotGraphBodyWriter>
    where TSection : DotCommonGraphSection, IDotGraphSection
{
    protected DotGraphSectionGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
        : base(syntaxRules, options, entityGenerators)
    {
    }

    protected abstract bool PreferGraphAttributesAsStatements { get; }

    protected override void WriteEntity(TSection graphSection, IDotGraphBodyWriter writer)
    {
        // global node and edge attributes have to appear first, so that they are applied to all elements that come later in the output script
        WriteGlobalAttributes(
            graphSection.GetAttributes(_options),
            graphSection.Nodes.Attributes.Collection,
            graphSection.Edges.Attributes.Collection,
            writer
        );

        // subgraphs and clusters may also specify global node attributes, and these are applied only
        // if the nodes they contain do not appear earlier in the parent graph or subgraph
        WriteSubgraphs(graphSection.Subgraphs, writer);
        WriteClusters(graphSection.Clusters, writer);

        // as already mentioned, nodes should not appear before subgraphs and clusters
        WriteNodes(graphSection.Nodes, writer);

        WriteEdges(graphSection.Edges, writer);
    }

    protected virtual void WriteGlobalAttributes(DotAttributeCollection graphAttributes, DotAttributeCollection nodeAttributes, DotAttributeCollection edgeAttributes, IDotGraphBodyWriter writer)
    {
        var writeGraphAttributes = graphAttributes.Any();

        // write graph attributes as a list of individual statements
        if (PreferGraphAttributesAsStatements)
        {
            WriteGlobalGraphAttributesAsStatementList(graphAttributes, writer);
            writeGraphAttributes = false;
        }

        if (!nodeAttributes.Any() && !edgeAttributes.Any() && !writeGraphAttributes)
        {
            return;
        }

        var globalEntityAttributesStatementWriter = writer.BeginGlobalEntityAttributesSection(_options.PreferStatementDelimiter);

        if (writeGraphAttributes)
        {
            // write graph attributes as a "graph [attr_list]" clause
            WriteGlobalGraphAttributesAsClause(graphAttributes, globalEntityAttributesStatementWriter);
        }

        WriteGlobalNodeAttributes(nodeAttributes, globalEntityAttributesStatementWriter);
        WriteGlobalEdgeAttributes(edgeAttributes, globalEntityAttributesStatementWriter);

        writer.EndGlobalEntityAttributesSection();
    }

    protected virtual void WriteGlobalGraphAttributesAsStatementList(DotAttributeCollection attributes, IDotGraphBodyWriter writer)
    {
        if (attributes.Any())
        {
            var globalGraphAttributeStatementWriter = writer.BeginGlobalGraphAttributesSection(_options.PreferStatementDelimiter);
            _entityGenerators.GetForEntity<IDotGlobalGraphAttributeStatementWriter>(attributes).Generate(attributes, globalGraphAttributeStatementWriter);
            writer.EndGlobalGraphAttributesSection();
        }
    }

    protected virtual void WriteGlobalGraphAttributesAsClause(DotAttributeCollection attributes, IDotGlobalEntityAttributesStatementWriter writer)
    {
        if (attributes.Any())
        {
            var globalGraphAttributesWriter = writer.BeginGraphAttributesStatement();
            _entityGenerators.GetForEntity<IDotGlobalGraphAttributesWriter>(attributes).Generate(attributes, globalGraphAttributesWriter);
            writer.EndGraphAttributesStatement();
        }
    }

    protected virtual void WriteGlobalNodeAttributes(DotAttributeCollection attributes, IDotGlobalEntityAttributesStatementWriter writer)
    {
        if (attributes.Any())
        {
            var globalNodeAttributesWriter = writer.BeginNodeAttributesStatement();
            _entityGenerators.GetForEntity<IDotGlobalNodeAttributesWriter>(attributes)
               .Generate(attributes, globalNodeAttributesWriter);
            writer.EndNodeAttributesStatement();
        }
    }

    protected virtual void WriteGlobalEdgeAttributes(DotAttributeCollection attributes, IDotGlobalEntityAttributesStatementWriter writer)
    {
        if (attributes.Any())
        {
            var globalEdgeAttributesWriter = writer.BeginEdgeAttributesStatement();
            _entityGenerators.GetForEntity<IDotGlobalEdgeAttributesWriter>(attributes)
               .Generate(attributes, globalEdgeAttributesWriter);
            writer.EndEdgeAttributesStatement();
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
        if (subgraphs.Any())
        {
            var subgraphWriterRoot = writer.BeginSubgraphsSection();
            _entityGenerators.GetForEntity<IDotSubgraphWriterRoot>(subgraphs).Generate(subgraphs, subgraphWriterRoot);
            writer.EndSubgraphsSection();
        }
    }

    protected virtual void WriteClusters(DotClusterCollection clusters, IDotGraphBodyWriter writer)
    {
        if (clusters.Any())
        {
            var subgraphWriterRoot = writer.BeginClustersSection();
            _entityGenerators.GetForEntity<IDotSubgraphWriterRoot>(clusters).Generate(clusters, subgraphWriterRoot);
            writer.EndClustersSection();
        }
    }
}