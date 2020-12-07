using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Types.Identifiers;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Generators.Edges
{
    public class DotClusterEndpointGenerator : DotEndpointGenerator<DotClusterEndpoint>
    {
        public DotClusterEndpointGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override string EncodeEndpointIdentifier(string endpointId)
        {
            return EncodeIdentifier(new DotClusterId(endpointId));
        }
    }
}