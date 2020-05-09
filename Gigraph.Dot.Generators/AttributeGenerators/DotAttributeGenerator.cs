using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes;
using Gigraph.Dot.Generators.Options;

namespace Gigraph.Dot.Generators.AttributeGenerators
{
    public class DotAttributeGenerator : DotGenericAttributeGenerator<IDotAttribute>
    {
        public DotAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }
    }
}
