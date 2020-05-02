﻿using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotWriters;
using Dotless.Writers.Options;

namespace Dotless.Writers.AttributeWriters
{
    public class DotHtmlLabelAttributeWriter : DotTextualAttributeWriter<DotHtmlLabel>
    {
        public DotHtmlLabelAttributeWriter(DotSyntaxRules syntaxRules, DotWriterOptions options, DotEntityWriterCollection entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteAttribute(string key, string value, DotStringWriter writer)
        {
            writer
                .AssertContext<DotStringWriter.AttributeListContext>()
                .WriteHtmlAttribute(key, value);
        }
    }
}
