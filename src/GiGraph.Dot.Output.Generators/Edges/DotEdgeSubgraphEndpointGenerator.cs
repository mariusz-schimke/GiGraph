using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Edges;
using GiGraph.Dot.Output.Writers.Subgraphs;

namespace GiGraph.Dot.Output.Generators.Edges
{
    public class DotEdgeSubgraphEndpointGenerator : DotEntityGenerator<DotSubgraphEndpoint, IDotEdgeWriter>
    {
        public DotEdgeSubgraphEndpointGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotSubgraphEndpoint endpoint, IDotEdgeWriter writer)
        {
            var subgraphWriter = writer.BeginSubgraph(_options.Edges.PreferExplicitSubgraphDeclaration);
            _entityGenerators.GetForEntity<IDotSubgraphWriter>(endpoint.Subgraph).Generate(endpoint.Subgraph, subgraphWriter);
            writer.EndSubgraph();
        }
    }
}