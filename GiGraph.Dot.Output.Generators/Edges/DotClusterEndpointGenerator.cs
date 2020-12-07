using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Edges.Endpoints;
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

        protected override string EscapeEndpointIdentifier(string endpointId)
        {
            return _syntaxRules.IdentifierEscaper.Escape(DotClusterIdFormatter.Format(endpointId, _options));
        }
    }
}