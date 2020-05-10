using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Subgraphs;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.SubgraphWriters;

namespace Gigraph.Dot.Generators.SubgraphGenerators
{
    public class DotSubgraphGenerator : DotGenericSubgraphGenerator<DotSubgraph>
    {
        public DotSubgraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotSubgraph subgraph, IDotSubgraphWriter writer)
        {
            WriteDeclaration(subgraph.Id, isCluster: false, writer);
            WriteBody(subgraph, writer);
        }
    }
}
