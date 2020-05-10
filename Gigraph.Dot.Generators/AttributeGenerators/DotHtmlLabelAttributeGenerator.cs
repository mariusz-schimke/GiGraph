using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Writers.AttributeWriters;

namespace Gigraph.Dot.Generators.AttributeGenerators
{
    public class DotHtmlLabelAttributeGenerator : DotGenericAttributeGenerator<DotHtmlLabelAttribute>
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
