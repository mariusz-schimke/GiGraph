using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.TextEscaping;
using GiGraph.Dot.Output.Writers.AttributeWriters;

namespace GiGraph.Dot.Output.Generators.AttributeGenerators
{
    public class DotStringAttributeGenerator : DotAttributeGenerator<DotLabelStringAttribute>
    {
        protected DotStringAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, IDotTextEscaper identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotStringAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotLabelStringAttribute attribute, IDotAttributeWriter writer)
        {
            var value = ((IDotEncodableValue) attribute).GetDotEncodedValue(_options);

            if (attribute.Value is DotLabelHtml)
            {
                WriteHtmlAttribute(attribute.Key, value, writer);
            }
            else
            {
                WriteAttribute(attribute.Key, value, writer);
            }
        }

        protected virtual void WriteHtmlAttribute(string key, string value, IDotAttributeWriter writer)
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