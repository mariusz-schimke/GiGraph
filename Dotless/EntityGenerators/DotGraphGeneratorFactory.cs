using Dotless.Core;
using Dotless.EntityGenerators.AttributeGenerators;
using Dotless.EntityGenerators.GraphGenerators;
using Dotless.EntityGenerators.NodeGenerators;
using Dotless.EntityGenerators.Options;

namespace Dotless.EntityGenerators
{
    // TODO: dokończyć tę klasę (jakieś interfejsy, możliwość modyfikacji/dostarczenia providerów)
    public static class DotGraphGeneratorFactory
    {
        public static DotGraphGenerator CreateDefault()
        {
            var syntaxRules = new DotSyntaxRules();
            var dotWriterOptions = new DotGenerationOptions();
            var converters = new DotEntityGeneratorsProvider();

            converters.Register(new DotGraphGenerator(syntaxRules, dotWriterOptions, converters));
            converters.Register(new DotSubgraphGenerator(syntaxRules, dotWriterOptions, converters));

            converters.Register(new DotAttributeCollectionGenerator(syntaxRules, dotWriterOptions, converters));

            converters.Register(new DotTextLabelAttributeGenerator(syntaxRules, dotWriterOptions, converters));
            converters.Register(new DotHtmlLabelAttributeGenerator(syntaxRules, dotWriterOptions, converters));

            converters.Register(new DotNodeGenerator(syntaxRules, dotWriterOptions, converters));
            converters.Register(new DotNodeCollectionGenerator(syntaxRules, dotWriterOptions, converters));

            return new DotGraphGenerator(syntaxRules, dotWriterOptions, converters);
        }
    }
}
