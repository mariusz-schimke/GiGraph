using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Metadata;
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
            var id = EncodeEndpointIdentifier(endpoint.Id);
            var portName = EncodeIdentifier(endpoint.Port.Name);

            var compassPoint = endpoint.Port.CompassPoint.HasValue
                ? DotAttributeValue.Get(endpoint.Port.CompassPoint.Value)
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

        protected virtual string EncodeEndpointIdentifier(string endpointId)
        {
            return EncodeIdentifier(endpointId);
        }
    }
}