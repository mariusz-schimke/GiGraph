using Dotless.Attributes;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public class DotHtmlLabelAttributeGenerator : DotTextualAttributeGenerator<DotHtmlLabel>
    {
        protected override ICollection<IDotToken>? ConvertValueToTokens(DotHtmlLabel attribute)
        {
            if (attribute.Value is { })
            {
                return new List<IDotToken>()
                    .BracedHtmlText(EscapeValue(attribute.Value)!);
            }

            return null;
        }
    }
}
