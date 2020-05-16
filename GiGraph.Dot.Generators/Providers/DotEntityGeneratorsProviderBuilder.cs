using GiGraph.Dot.Core;
using GiGraph.Dot.Generators.AttributeGenerators;
using GiGraph.Dot.Generators.EdgeGenerators;
using GiGraph.Dot.Generators.GraphGenerators;
using GiGraph.Dot.Generators.NodeGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.SubgraphGenerators;

namespace GiGraph.Dot.Generators.Providers
{
    public class DotEntityGeneratorsProviderBuilder : IDotEntityGeneratorsProviderBuilder
    {
        /// <summary>
        /// Builds a provider with all generators necessary to generate a graph.
        /// </summary>
        /// <param name="syntaxRules">The syntax rules to follow.</param>
        /// <param name="options">The DOT language generation options to use for graph generation and its components.</param>
        public virtual IDotEntityGeneratorsProvider Build(DotSyntaxRules syntaxRules, DotGenerationOptions options)
        {
            var provider = new DotEntityGeneratorsProvider();

            provider.Register(new DotGraphGenerator(syntaxRules, options, provider));
            provider.Register(new DotGraphBodyGenerator(syntaxRules, options, provider));

            provider.Register(new DotClusterGenerator(syntaxRules, options, provider));
            provider.Register(new DotSubgraphGenerator(syntaxRules, options, provider));
            provider.Register(new DotCommonSubgraphCollectionGenerator(syntaxRules, options, provider));

            provider.Register(new DotCustomAttributeGenerator(syntaxRules, options, provider));
            provider.Register(new DotAttributeCollectionGenerator(syntaxRules, options, provider));
            provider.Register(new DotHtmlLabelAttributeGenerator(syntaxRules, options, provider));

            provider.Register(new DotNodeDefaultsGenerator(syntaxRules, options, provider));
            provider.Register(new DotEdgeDefaultsGenerator(syntaxRules, options, provider));

            provider.Register(new DotNodeGenerator(syntaxRules, options, provider));
            provider.Register(new DotNodeCollectionGenerator(syntaxRules, options, provider));

            provider.Register(new DotEdgeGenerator(syntaxRules, options, provider));
            provider.Register(new DotEdgeCollectionGenerator(syntaxRules, options, provider));

            return provider;
        }
    }
}
