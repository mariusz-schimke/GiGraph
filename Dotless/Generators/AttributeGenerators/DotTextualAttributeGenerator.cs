using Dotless.Attributes;
using Dotless.TextEscaping;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public abstract class DotTextualAttributeGenerator<TAttribute> : DotAttributeGenerator<TAttribute, string>
        where TAttribute : DotAttribute<string>
    {
        public List<IDotTextEscaper> ValueEscapingPipeline { get; } = new List<IDotTextEscaper>();

        protected DotTextualAttributeGenerator()
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
