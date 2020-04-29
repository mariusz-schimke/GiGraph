using Dotless.Attributes;
using Dotless.Core;
using Dotless.TextEscaping;
using System;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public abstract class DotTextualAttributeGenerator<TAttribute> : DotAttributeGenerator<TAttribute>
        where TAttribute : DotAttribute<string>
    {
        public DotTextualAttributeGenerator(DotSyntaxRules syntaxRules, DotEntityGeneratorCollection entityGenerators)
            : base(syntaxRules, entityGenerators)
        {
        }

        protected virtual ICollection<IDotTextEscaper> GetValueEscapingPipeline(DotEntityGeneratorOptions options)
        {
            return Array.Empty<IDotTextEscaper>();
        }

        protected virtual string? EscapeValue(string? value, DotEntityGeneratorOptions options)
        {
            foreach (var escaper in GetValueEscapingPipeline(options))
            {
                value = escaper.Escape(value);
            }

            return value;
        }
    }
}
