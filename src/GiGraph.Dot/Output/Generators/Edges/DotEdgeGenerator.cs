using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Edges;

namespace GiGraph.Dot.Output.Generators.Edges;

public class DotEdgeGenerator : DotEntityWithAttributeListGenerator<DotEdgeDefinition, IDotEdgeWriter>
{
    public DotEdgeGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
        : base(syntaxRules, options, entityGenerators)
    {
    }

    protected override void WriteEntity(DotEdgeDefinition edge, IDotEdgeWriter writer)
    {
        WriteEdges(edge.Endpoints, writer);
        WriteAttributes(edge.Attributes.Collection, writer);
    }

    protected virtual void WriteEdges(DotEndpointDefinition[] endpoints, IDotEdgeWriter writer)
    {
        if (endpoints.Length < 2)
        {
            throw new ArgumentException("At least a pair of endpoints has to be specified for an edge or an edge sequence.", nameof(endpoints));
        }

        foreach (var endpoint in endpoints)
        {
            WriteEndpoint(endpoint, writer);
            writer.WriteEdge();
        }
    }

    protected virtual void WriteEndpoint(DotEndpointDefinition endpoint, IDotEdgeWriter writer)
    {
        _entityGenerators.GetForEntity<IDotEdgeWriter>(endpoint).Generate(endpoint, writer, annotate: false);
    }
}