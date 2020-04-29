using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public class DotHtmlLabelAttributeGenerator : DotTextualAttributeGenerator<DotHtmlLabel>
    {
        public DotHtmlLabelAttributeGenerator(DotSyntaxRules syntaxRules, DotEntityGeneratorCollection entityGenerators)
            : base(syntaxRules, entityGenerators)
        {
        }

        protected override ICollection<IDotToken>? ConvertValueToTokens(DotHtmlLabel attribute, DotEntityGeneratorOptions options)
        {
            if (attribute.Value is { })
            {
                return new List<IDotToken>().BracedHtmlText(EscapeValue(attribute.Value, options)!);
            }

            return null;
        }
    }
}
