using Dotless.TextEscaping;

namespace Dotless.Attributes
{
    public class DotTextLabel : DotLabel
    {
        public DotTextLabel(string value)
            : base(value)
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

        public static implicit operator DotTextLabel(string value)
        {
            return new DotTextLabel(value);
        }
    }
}
