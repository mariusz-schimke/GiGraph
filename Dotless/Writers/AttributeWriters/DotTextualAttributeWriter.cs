using Dotless.Attributes;
using Dotless.Core;
using Dotless.TextEscaping;
using Dotless.Writers.Options;
using System;
using System.Collections.Generic;

namespace Dotless.Writers.AttributeWriters
{
    public abstract class DotTextualAttributeWriter<TAttribute> : DotAttributeWriter<TAttribute>
        where TAttribute : DotAttribute<string>
    {
        public DotTextualAttributeWriter(DotSyntaxRules syntaxRules, DotWriterOptions options, DotEntityWriterCollection entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override string GetAttributeValue(TAttribute attribute)
        {
            return EscapeValue(((IDotAttribute<string>)attribute).Value);
        }

        protected virtual ICollection<IDotTextEscaper> GetValueEscapingPipeline()
        {
            return Array.Empty<IDotTextEscaper>();
        }

        protected virtual string EscapeValue(string value)
        {
            foreach (var escaper in GetValueEscapingPipeline())
            {
                value = escaper.Escape(value)!;
            }

            return value;
        }
    }
}
