using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Attributes;

namespace GiGraph.Dot.Output.Generators.Attributes
{
    public class DotHtmlLabelAttributeGenerator : DotAttributeGenerator<DotAttribute>
    {
        public DotHtmlLabelAttributeGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteAttribute(string key, string value, IDotAttributeWriter writer)
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

        protected override bool Supports(DotAttribute entity)
        {
            return entity.GetValue() is DotHtmlLabel;
        }
    }
}