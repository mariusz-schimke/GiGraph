using Dotless.TextEscaping;
using System.Collections.Generic;

namespace Dotless.Attributes
{
    public abstract class DotTextualAttribute : DotAttribute<string>
    {
        public List<ITextEscaper> ValueEscapingPipeline { get; } = new List<ITextEscaper>();

        public DotTextualAttribute(string key, string value)
            : base(key, value)
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

        protected override string? Render(bool minified)
        {
            return _value is { }
                ? $@"{_key}{(minified ? "=" : " = ")}{QuoteValue(EscapeValue(_value))}"
                : null;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
