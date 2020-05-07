using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotWriters;
using Dotless.EntityGenerators.Options;

namespace Dotless.EntityGenerators.AttributeGenerators
{
    public class DotHtmlLabelAttributeGenerator : DotGenericAttributeGenerator<DotHtmlLabel>
    {
        public DotHtmlLabelAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override string EscapeValue(string value)
        {
            // do not escape HTML value
            return value;
        }

        protected override void WriteAttribute(string key, string value, IDotAttributeWriter writer)
        {
            writer.WriteHtmlAttribute
            (
                key,
                quoteKey: KeyRequiresQuoting(key),
                value,
                braceValue: true
            );
        }
    }
}
