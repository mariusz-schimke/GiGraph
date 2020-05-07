using Dotless.Attributes;
using Dotless.Core;
using Dotless.EntityGenerators.Options;

namespace Dotless.EntityGenerators.AttributeGenerators
{
    public class DotStringAttributeGenerator<TAttribute> : DotAttributeGenerator<TAttribute, string>
        where TAttribute : IDotAttribute<string>
    {
        public DotStringAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override string GetStringValue(string value)
        {
            return value;
        }
    }
}
