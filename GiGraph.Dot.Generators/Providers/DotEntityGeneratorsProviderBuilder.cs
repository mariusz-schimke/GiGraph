﻿using GiGraph.Dot.Entities.Subgraphs;
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
            provider.Register(new DotCommonSubgraphCollectionGenerator<DotSubgraph>(syntaxRules, options, provider));
            provider.Register(new DotCommonSubgraphCollectionGenerator<DotCluster>(syntaxRules, options, provider));

            provider.Register(new DotCommonAttributeGenerator(syntaxRules, options, provider));
            provider.Register(new DotCustomAttributeGenerator(syntaxRules, options, provider));
            provider.Register(new DotHtmlAttributeGenerator(syntaxRules, options, provider));
            provider.Register(new DotCommonAttributeCollectionGenerator(syntaxRules, options, provider));

            provider.Register(new DotNodeDefaultsGenerator(syntaxRules, options, provider));
            provider.Register(new DotEdgeDefaultsGenerator(syntaxRules, options, provider));

            provider.Register(new DotNodeGenerator(syntaxRules, options, provider));
            provider.Register(new DotNodeGroupGenerator(syntaxRules, options, provider));
            provider.Register(new DotCommonNodeCollectionGenerator(syntaxRules, options, provider));

            provider.Register(new DotCommonEdgeGenerator(syntaxRules, options, provider));
            provider.Register(new DotCommonEdgeCollectionGenerator(syntaxRules, options, provider));

            return provider;
        }
    }
}
