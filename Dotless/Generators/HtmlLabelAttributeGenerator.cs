using Dotless.Attributes;

namespace Dotless.Generators
{
    public class HtmlLabelAttributeGenerator : TextualAttributeGenerator<HtmlLabel>
    {
        public HtmlLabelAttributeGenerator()
        {
        }

        protected override string? QuoteValue(string? value)
        {
            return $@"<{value}>";
        }
    }
}
