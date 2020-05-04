using Dotless.Attributes;
using Dotless.Core;
using Dotless.EntityGenerators.Options;
using Dotless.TextEscaping;
using System;
using System.Collections.Generic;

namespace Dotless.EntityGenerators.AttributeGenerators
{
    public abstract class DotTextualAttributeGenerator<TAttribute> : DotAttributeGenerator<TAttribute>
        where TAttribute : DotAttribute<string>
    {
        public DotTextualAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
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
