using Dotless.Attributes;
using Dotless.Core;
using Dotless.TextEscaping;
using Dotless.EntityGenerators.Options;
using System.Collections.Generic;

namespace Dotless.EntityGenerators.AttributeGenerators
{
    public class DotTextLabelAttributeGenerator : DotTextualAttributeGenerator<DotTextLabel>
    {
        public DotTextLabelAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override ICollection<IDotTextEscaper> GetValueEscapingPipeline()
        {
            var result = new List<IDotTextEscaper>();

            if (_options.Attributes.HtmlEscapeLabelText)
            {
                result.Add(new DotHtmlEscaper());
            }

            result.Add(new DotBackslashEscaper());
            result.Add(new DotQuotationMarkEscaper());
            result.Add(new DotLineBreakEscaper());

            return result;
        }
    }
}
