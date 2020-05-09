using Dotless.Core;
using Dotless.EntityGenerators.AttributeGenerators;
using Dotless.EntityGenerators.Edges;
using Dotless.EntityGenerators.NodeGenerators;
using Dotless.EntityGenerators.Options;

namespace Dotless.EntityGenerators.GraphGenerators
{
    // TODO: dokończyć tę klasę (jakieś interfejsy, możliwość modyfikacji/dostarczenia providerów)
    public static class DotGraphGeneratorFactory
    {
        public static DotGraphGenerator CreateDefault(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            var converters = new DotEntityGeneratorsProvider();

            converters.Register(new DotGraphGenerator(syntaxRules, options, converters));
            converters.Register(new DotGraphBodyGenerator(syntaxRules, options, converters));

            converters.Register(new DotSubgraphGenerator(syntaxRules, options, converters));

            converters.Register(new DotAttributeCollectionGenerator(syntaxRules, options, converters));

            converters.Register(new DotAttributeGenerator(syntaxRules, options, converters));
            converters.Register(new DotHtmlLabelAttributeGenerator(syntaxRules, options, converters));

            converters.Register(new DotNodeGenerator(syntaxRules, options, converters));
            converters.Register(new DotNodeCollectionGenerator(syntaxRules, options, converters));

            converters.Register(new DotEdgeGenerator(syntaxRules, options, converters));
            converters.Register(new DotEdgeCollectionGenerator(syntaxRules, options, converters));

            return new DotGraphGenerator(syntaxRules, options, converters);
        }
    }
}
