﻿using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using Dotless.TextEscaping;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public class DotTextLabelAttributeGenerator : DotTextualAttributeGenerator<DotTextLabel>
    {
        public DotTextLabelAttributeGenerator(DotSyntaxRules syntaxRules, DotEntityGeneratorCollection entityGenerators)
            : base(syntaxRules, entityGenerators)
        {
        }

        protected override ICollection<IDotToken>? ConvertValueToTokens(DotTextLabel attribute, DotEntityGeneratorOptions options)
        {
            if (attribute.Value is null)
            {
                return null;
            }

            var escapedValue = EscapeValue(attribute.Value)!;

            if (RequiresQuoting(escapedValue, options))
            {
                return new List<IDotToken>().QuotedText(escapedValue);
            }

            return new List<IDotToken>().Text(escapedValue);
        }

        protected virtual bool RequiresQuoting(string value, DotEntityGeneratorOptions options)
        {
            return options.Attributes.PreferQuotedValue || !_syntaxRules.IsValidIdentifier(value);
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
