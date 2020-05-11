using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes;
using Gigraph.Dot.Entities.Attributes.LabelAttributes;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.AttributeWriters;

namespace Gigraph.Dot.Generators.AttributeGenerators
{
    public class DotHtmlLabelAttributeGenerator : DotAttributeGenerator<DotHtmlLabelAttribute>
    {
        public DotHtmlLabelAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteAttribute(DotHtmlLabelAttribute attribute, IDotAttributeWriter writer)
        {
            var key = EscapeKey(((IDotAttribute)attribute).Key);

            // don't escape the HTML value
            var value = ((IDotAttribute)attribute).Value;

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
