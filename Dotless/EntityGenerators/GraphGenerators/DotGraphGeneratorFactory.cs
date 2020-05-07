using Dotless.Core;
using Dotless.EntityGenerators.AttributeGenerators;
using Dotless.EntityGenerators.Edges;
using Dotless.EntityGenerators.NodeGenerators;
using Dotless.EntityGenerators.Options;
using System;

namespace Dotless.EntityGenerators.GraphGenerators
{
    // TODO: dokończyć tę klasę (jakieś interfejsy, możliwość modyfikacji/dostarczenia providerów)
    public static class DotGraphGeneratorFactory
    {
        public static DotGraphGenerator CreateDefault(Action<DotGenerationOptions> setOptions = null, Action<DotSyntaxRules> setSyntaxRules = null)
        {
            var syntaxRules = new DotSyntaxRules();
            var options = new DotGenerationOptions();
            var converters = new DotEntityGeneratorsProvider();

            setOptions?.Invoke(options);
            setSyntaxRules?.Invoke(syntaxRules);

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
