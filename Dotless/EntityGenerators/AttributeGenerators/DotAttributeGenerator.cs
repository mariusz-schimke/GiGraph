using Dotless.Attributes;
using Dotless.Core;
using Dotless.EntityGenerators.Options;

namespace Dotless.EntityGenerators.AttributeGenerators
{
    public class DotAttributeGenerator : DotGenericAttributeGenerator<IDotAttribute>
    {
        public DotAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }
    }
}
