using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;

namespace Gigraph.Dot.Generators.AttributeGenerators
{
    public class DotAttributeGenerator : DotGenericAttributeGenerator<IDotAttribute>
    {
        public DotAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }
    }
}
