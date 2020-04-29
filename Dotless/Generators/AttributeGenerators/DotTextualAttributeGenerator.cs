using Dotless.Attributes;
using Dotless.Core;
using Dotless.TextEscaping;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public abstract class DotTextualAttributeGenerator<TAttribute> : DotAttributeGenerator<TAttribute>
        where TAttribute : DotAttribute<string>
    {
        public List<IDotTextEscaper> ValueEscapingPipeline { get; } = new List<IDotTextEscaper>();

        public DotTextualAttributeGenerator(DotSyntaxRules syntaxRules, DotEntityGeneratorCollection entityGenerators)
            : base(syntaxRules, entityGenerators)
        {
            PrepareValueEscapingPipeline();
        }

        protected virtual void PrepareValueEscapingPipeline()
        {
        }

        protected virtual string? EscapeValue(string? value)
        {
            foreach (var escaper in ValueEscapingPipeline)
            {
                value = escaper.Escape(value);
            }

            return value;
        }
    }
}
