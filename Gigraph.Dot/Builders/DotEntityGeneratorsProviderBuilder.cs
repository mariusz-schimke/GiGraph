using Gigraph.Dot.Core;
using Gigraph.Dot.Generators;
using Gigraph.Dot.Generators.AttributeGenerators;
using Gigraph.Dot.Generators.Edges;
using Gigraph.Dot.Generators.GraphGenerators;
using Gigraph.Dot.Generators.NodeGenerators;
using Gigraph.Dot.Generators.Options;

namespace Gigraph.Dot.Builders
{
    public class DotEntityGeneratorsProviderBuilder
    {
        /// <summary>
        /// Builds a provider with all generators necessary to generate a graph.
        /// </summary>
        /// <param name="syntaxRules">The syntax rules to follow.</param>
        /// <param name="options">The DOT language generation options to use for graph generation and its components.</param>
        public virtual DotEntityGeneratorsProvider Build(DotSyntaxRules syntaxRules, DotGenerationOptions options)
        {
            var provider = new DotEntityGeneratorsProvider();

            provider.Register(new DotGraphGenerator(syntaxRules, options, provider));
            provider.Register(new DotSubgraphGenerator(syntaxRules, options, provider));
            provider.Register(new DotGraphBodyGenerator(syntaxRules, options, provider));

            provider.Register(new DotAttributeGenerator(syntaxRules, options, provider));
            provider.Register(new DotAttributeCollectionGenerator(syntaxRules, options, provider));
            provider.Register(new DotHtmlLabelAttributeGenerator(syntaxRules, options, provider));

            provider.Register(new DotNodeGenerator(syntaxRules, options, provider));
            provider.Register(new DotNodeCollectionGenerator(syntaxRules, options, provider));

            provider.Register(new DotEdgeGenerator(syntaxRules, options, provider));
            provider.Register(new DotEdgeCollectionGenerator(syntaxRules, options, provider));

            return provider;
        }
    }
}
