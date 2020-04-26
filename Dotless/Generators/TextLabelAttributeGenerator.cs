using Dotless.Attributes;
using Dotless.TextEscaping;

namespace Dotless.Generators
{
    public class TextLabelAttributeGenerator : TextualAttributeGenerator<TextLabel>
    {
        public TextLabelAttributeGenerator()
            : base()
        {
        }

        protected override void PrepareValueEscapingPipeline()
        {
            ValueEscapingPipeline.Add(new HtmlEscaper());
            ValueEscapingPipeline.Add(new BackslashEscaper());
            ValueEscapingPipeline.Add(new QuotationMarkEscaper());
            ValueEscapingPipeline.Add(new LineBreakEscaper());
        }

        protected override string? QuoteValue(string? value)
        {
            return $"\"{value}\"";
        }
    }
}
