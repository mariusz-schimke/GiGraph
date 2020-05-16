using GiGraph.Dot.Core;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;

namespace GiGraph.Dot.Generators.SubgraphGenerators
{
    public class DotClusterGenerator : DotCommonSubgraphGenerator<DotCluster>
    {
        public DotClusterGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators, isCluster: true)
        {
        }
    }
}
