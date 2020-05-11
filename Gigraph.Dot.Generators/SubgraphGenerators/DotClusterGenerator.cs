using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Subgraphs;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;

namespace Gigraph.Dot.Generators.SubgraphGenerators
{
    public class DotClusterGenerator : DotCommonSubgraphGenerator<DotCluster>
    {
        public DotClusterGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators, isCluster: true)
        {
        }
    }
}
