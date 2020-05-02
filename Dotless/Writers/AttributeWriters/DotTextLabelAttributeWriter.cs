using Dotless.Attributes;
using Dotless.Core;
using Dotless.TextEscaping;
using Dotless.Writers.Options;
using System.Collections.Generic;

namespace Dotless.Writers.AttributeWriters
{
    public class DotTextLabelAttributeWriter : DotTextualAttributeWriter<DotTextLabel>
    {
        public DotTextLabelAttributeWriter(DotSyntaxRules syntaxRules, DotWriterOptions options, DotEntityWriterCollection entityGenerators)
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
