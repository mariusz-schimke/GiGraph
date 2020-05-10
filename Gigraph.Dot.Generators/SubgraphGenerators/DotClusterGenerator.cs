using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Subgraphs;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.SubgraphWriters;

namespace Gigraph.Dot.Generators.SubgraphGenerators
{
    public class DotClusterGenerator : DotGenericSubgraphGenerator<DotCluster>
    {
        public DotClusterGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCluster cluster, IDotSubgraphWriter writer)
        {
            WriteDeclaration(cluster.Id, isCluster: true, writer);
            WriteBody(cluster, writer);
        }
    }
}
