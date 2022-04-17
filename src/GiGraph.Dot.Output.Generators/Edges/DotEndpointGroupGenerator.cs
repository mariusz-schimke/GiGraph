using System;
using System.Linq;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Output.Writers.Edges;

namespace GiGraph.Dot.Output.Generators.Edges;

public class DotEndpointGroupGenerator : DotEntityGenerator<DotEndpointGroup, IDotEndpointGroupWriter>
{
    public DotEndpointGroupGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
        : base(syntaxRules, options, entityGenerators)
    {
    }

    protected override void WriteEntity(DotEndpointGroup endpointGroup, IDotEndpointGroupWriter writer)
    {
        var orderedEndpoints = _options.SortElements
            ? endpointGroup.Endpoints
               .Cast<IDotOrderable>()
               .OrderBy(endpoint => endpoint.OrderingKey, StringComparer.InvariantCulture)
               .Cast<DotEndpoint>()
            : endpointGroup.Endpoints;

        foreach (var endpoint in orderedEndpoints)
        {
            WriteEndpoint(endpoint, writer);
        }
    }

    protected virtual void WriteEndpoint(DotEndpoint endpoint, IDotEndpointGroupWriter writer)
    {
        var endpointWriter = writer.BeginEndpoint();
        _entityGenerators.GetForEntity<IDotEndpointWriter>(endpoint).Generate(endpoint, endpointWriter);
        writer.EndEndpoint();
    }
}