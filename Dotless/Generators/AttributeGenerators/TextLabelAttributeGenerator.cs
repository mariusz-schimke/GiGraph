using Dotless.Attributes;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using Dotless.TextEscaping;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public class TextLabelAttributeGenerator : TextualAttributeGenerator<TextLabel>
    {
        public override ICollection<IToken> Generate(TextLabel attribute)
        {
            var result = new List<IToken>();

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
            ValueEscapingPipeline.Add(new HtmlEscaper());
            ValueEscapingPipeline.Add(new BackslashEscaper());
            ValueEscapingPipeline.Add(new QuotationMarkEscaper());
            ValueEscapingPipeline.Add(new LineBreakEscaper());
        }
    }
}
