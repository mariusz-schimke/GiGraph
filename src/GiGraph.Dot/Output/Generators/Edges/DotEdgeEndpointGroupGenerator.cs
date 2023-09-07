using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Edges;

namespace GiGraph.Dot.Output.Generators.Edges;

public class DotEdgeEndpointGroupGenerator : DotEntityGenerator<DotEndpointGroup, IDotEdgeWriter>
{
    public DotEdgeEndpointGroupGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
        : base(syntaxRules, options, entityGenerators)
    {
    }

    protected override void WriteEntity(DotEndpointGroup endpointGroup, IDotEdgeWriter writer)
    {
        var endpointGroupWriter = writer.BeginEndpointGroup();
        _entityGenerators.GetForEntity<IDotEndpointGroupWriter>(endpointGroup).Generate(endpointGroup, endpointGroupWriter);
        writer.EndEndpointGroup();
    }
}