using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;

namespace GiGraph.Dot.Generators.SubgraphGenerators
{
    public class DotSubgraphGenerator : DotCommonSubgraphGenerator<DotSubgraph>
    {
        protected DotSubgraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper, isCluster: false)
        {
        }

        public DotSubgraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : this(syntaxRules, options, entityGenerators, identifierEscaper: null)
        {
        }
    }
}
