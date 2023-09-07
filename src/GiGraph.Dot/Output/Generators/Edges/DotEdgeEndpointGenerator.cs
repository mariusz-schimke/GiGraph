using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Edges;

namespace GiGraph.Dot.Output.Generators.Edges;

public class DotEdgeEndpointGenerator : DotEntityGenerator<DotEndpoint, IDotEdgeWriter>
{
    public DotEdgeEndpointGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
        : base(syntaxRules, options, entityGenerators)
    {
    }

    protected override void WriteEntity(DotEndpoint endpoint, IDotEdgeWriter writer)
    {
        var endpointWriter = writer.BeginEndpoint();
        _entityGenerators.GetForEntity<IDotEndpointWriter>(endpoint).Generate(endpoint, endpointWriter);
        writer.EndEndpoint();
    }
}