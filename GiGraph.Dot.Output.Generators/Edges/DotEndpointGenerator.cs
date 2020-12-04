using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Edges;

namespace GiGraph.Dot.Output.Generators.Edges
{
    public class DotEndpointGenerator : DotEntityGenerator<DotEndpoint, IDotEndpointWriter>
    {
        public DotEndpointGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotEndpoint endpoint, IDotEndpointWriter writer)
        {
            var id = EscapeIdentifier(endpoint.Id);
            var portName = EscapeIdentifier(endpoint.Port.Name);

            var compassPoint = endpoint.Port.CompassPoint.HasValue
                ? DotCompassPointConverter.Convert(endpoint.Port.CompassPoint.Value)
                : null;

            writer.WriteEndpoint
            (
                id,
                IdentifierRequiresQuoting(id),
                portName,
                IdentifierRequiresQuoting(portName),
                compassPoint,
                IdentifierRequiresQuoting(compassPoint)
            );
        }
    }
}