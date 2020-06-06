using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Generators.TextEscaping;
using GiGraph.Dot.Output.Writers.AttributeWriters;

namespace GiGraph.Dot.Output.Generators.AttributeGenerators
{
    public class DotHtmlAttributeGenerator : DotAttributeGenerator<DotHtmlAttribute>
    {
        protected DotHtmlAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotHtmlAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteAttribute(string key, string value, IDotAttributeWriter writer)
        {
            key = EscapeIdentifier(key);
            value = EscapeValue(FormatValue(value));

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