using Dotless.Attributes;
using Dotless.Generators.Extensions;
using Dotless.TextEscaping;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public abstract class TextualAttributeGenerator<TAttribute> : AttributeGenerator<TAttribute, string>
        where TAttribute : Attribute<string>
    {
        public List<ITextEscaper> ValueEscapingPipeline { get; } = new List<ITextEscaper>();

        protected TextualAttributeGenerator()
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

        protected abstract string? QuoteValue(string? value);

        public override string? Generate(TAttribute attribute, GeneratorOptions o)
        {
            return attribute.Value is { }
                ? $@"{attribute.Key}{o.TS()}={o.TS()}{QuoteValue(EscapeValue(attribute.Value))}"
                : null;
        }
    }
}
