using System;
using System.Linq;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Output.Writers.Edges;

namespace GiGraph.Dot.Output.Generators.Edges;

public class DotEdgeCollectionGenerator : DotEntityGenerator<DotEdgeCollection, IDotEdgeStatementWriter>
{
    public DotEdgeCollectionGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
        : base(syntaxRules, options, entityGenerators)
    {
    }

    protected override void WriteEntity(DotEdgeCollection edges, IDotEdgeStatementWriter writer)
    {
        var orderedEdges = _options.SortElements
            ? edges.Cast<IDotOrderable>()
                .OrderBy(edge => edge.OrderingKey, StringComparer.InvariantCulture)
                .Cast<DotEdgeDefinition>()
            : edges;

        foreach (var edge in orderedEdges.Where(edge => edge.Endpoints.Length > 0))
        {
            WriteEdge(edge, writer);
        }
    }

    protected virtual void WriteEdge(DotEdgeDefinition edge, IDotEdgeStatementWriter writer)
    {
        var containsSubgraphs = edge.Endpoints.Any(e => e is DotSubgraphEndpoint);
        var containsAttributes = edge.Attributes.Collection.Any();

        var edgeWriter = writer.BeginEdgeStatement(containsSubgraphs, containsAttributes);
        _entityGenerators.GetForEntity<IDotEdgeWriter>(edge).Generate(edge, edgeWriter);
        writer.EndEdgeStatement();
    }
}