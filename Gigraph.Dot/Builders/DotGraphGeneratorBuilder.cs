using Gigraph.Dot.Core;
using Gigraph.Dot.Generators.GraphGenerators;
using Gigraph.Dot.Generators.Options;

namespace Gigraph.Dot.Builders
{
    // TODO: dokończyć tę klasę (jakieś interfejsy, możliwość modyfikacji/dostarczenia providerów)
    public class DotGraphGeneratorBuilder
    {
        protected readonly DotEntityGeneratorsProviderBuilder _dotEntityGeneratorsProviderBuilder;

        public DotGraphGeneratorBuilder(DotEntityGeneratorsProviderBuilder dotEntityGeneratorsProviderBuilder)
        {
            _dotEntityGeneratorsProviderBuilder = dotEntityGeneratorsProviderBuilder;
        }

        /// <summary>
        /// Builds a DOT graph generator initialized with entity generators provided to the current instance.
        /// </summary>
        /// <param name="syntaxRules">The syntax rules to follow.</param>
        /// <param name="options">The DOT language generation options to use for graph generation and its components.</param>
        public virtual DotGraphGenerator Build(DotSyntaxRules syntaxRules, DotGenerationOptions options)
        {
            var providers = _dotEntityGeneratorsProviderBuilder.Build(syntaxRules, options);
            return providers.Get<DotGraphGenerator>();
        }
    }
}
