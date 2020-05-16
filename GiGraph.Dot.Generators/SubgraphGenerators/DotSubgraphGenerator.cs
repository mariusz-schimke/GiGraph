using GiGraph.Dot.Core;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;

namespace GiGraph.Dot.Generators.SubgraphGenerators
{
    public class DotSubgraphGenerator : DotCommonSubgraphGenerator<DotSubgraph>
    {
        public DotSubgraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators, isCluster: false)
        {
        }
    }
}
