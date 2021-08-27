using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Output.Generators.Graphs;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Generators.Clusters
{
    public class DotClusterSectionGenerator : DotGraphSectionGenerator<DotClusterSection>
    {
        public DotClusterSectionGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override bool PreferGraphAttributesAsStatements => _options.Clusters.AttributesAsStatements;
    }
}