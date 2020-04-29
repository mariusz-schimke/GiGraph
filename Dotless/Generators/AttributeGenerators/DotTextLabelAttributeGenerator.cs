using Dotless.Attributes;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using Dotless.TextEscaping;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public class DotTextLabelAttributeGenerator : DotTextualAttributeGenerator<DotTextLabel>
    {
        public override ICollection<IDotToken> Generate(DotTextLabel attribute)
        {
            var result = new List<IDotToken>();

            if (attribute.Value is null)
            {
                return result;
            }

            result.AttributeKey(attribute.Key);
            result.AssignmentOperator();
            result.QuotedText(EscapeValue(attribute.Value)!);

            return result;
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
