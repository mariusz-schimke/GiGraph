using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Writers.AttributeWriters;

namespace GiGraph.Dot.Output.Generators.AttributeGenerators
{
    public class DotLabelAttributeGenerator : DotAttributeGenerator<DotLabelAttribute>
    {
        public DotLabelAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotLabelAttribute attribute, IDotAttributeWriter writer)
        {
            var value = ((IDotEncodable) attribute).GetDotEncodedValue(_options, _syntaxRules);

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
            key = EscapeKey(key);

            writer.WriteHtmlAttribute
            (
                key,
                quoteKey: KeyRequiresQuoting(key),
                value,
                writeInBrackets: true
            );
        }
    }
}