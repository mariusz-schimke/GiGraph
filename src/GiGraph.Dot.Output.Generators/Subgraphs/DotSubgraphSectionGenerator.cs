using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Generators.Graphs;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Generators.Subgraphs
{
    public class DotSubgraphSectionGenerator : DotGraphSectionGenerator<DotSubgraphSection>
    {
        public DotSubgraphSectionGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override bool PreferGraphAttributesAsStatements => _options.Subgraphs.AttributesAsStatements;
    }
}