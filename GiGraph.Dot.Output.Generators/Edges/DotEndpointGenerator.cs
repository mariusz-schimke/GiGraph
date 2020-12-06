using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Edges;

namespace GiGraph.Dot.Output.Generators.Edges
{
    public class DotEndpointGenerator<TEndpoint> : DotEntityGenerator<TEndpoint, IDotEndpointWriter>
        where TEndpoint : DotEndpoint
    {
        public DotEndpointGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(TEndpoint endpoint, IDotEndpointWriter writer)
        {
            var id = EscapeEndpointIdentifier(endpoint.Id);
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

        protected virtual string EscapeEndpointIdentifier(string endpointId)
        {
            return EscapeIdentifier(endpointId);
        }
    }
}