using Dotless.Attributes;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using Dotless.TextEscaping;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public class DotTextLabelAttributeGenerator : DotTextualAttributeGenerator<DotTextLabel>
    {
        protected override ICollection<IDotToken>? ConvertValueToTokens(DotTextLabel attribute)
        {
            if (attribute.Value is { })
            {
                return new List<IDotToken>()
                    .QuotedText(EscapeValue(attribute.Value)!);
            }

            return null;
        }

        protected override void PrepareValueEscapingPipeline()
        {
            ValueEscapingPipeline.Add(new DotHtmlEscaper());
            ValueEscapingPipeline.Add(new DotBackslashEscaper());
            ValueEscapingPipeline.Add(new DotQuotationMarkEscaper());
            ValueEscapingPipeline.Add(new DotLineBreakEscaper());
        }
    }
}
