using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Writers.AttributeWriters;

namespace Gigraph.Dot.Generators.AttributeGenerators
{
    public class DotGenericAttributeGenerator<TAttribute> : DotEntityGenerator<TAttribute, IDotAttributeWriter>
        where TAttribute : IDotAttribute
    {
        public DotGenericAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(TAttribute attribute, IDotAttributeWriter writer)
        {
            if (!attribute.HasValue)
            {
                return;
            }

            var escapedKey = EscapeKey(attribute.Key);
            var escapedValue = EscapeValue(attribute.Value);

            WriteAttribute(escapedKey, escapedValue, writer);
        }

        protected virtual void WriteAttribute(string key, string value, IDotAttributeWriter writer)
        {
            writer.WriteAttribute
            (
                key,
                quoteKey: KeyRequiresQuoting(key),
                value,
                quoteValue: ValueRequiresQuoting(value)
            );
        }

        protected virtual string EscapeKey(string key)
        {
            return _valueEscaper.Escape(key);
        }

        protected virtual string EscapeValue(string value)
        {
            return _valueEscaper.Escape(value);
        }

        protected virtual bool KeyRequiresQuoting(string key)
        {
            return !_syntaxRules.IsValidIdentifier(key);
        }

        protected virtual bool ValueRequiresQuoting(string value)
        {
            return _options.Attributes.PreferQuotedValue || !_syntaxRules.IsValidIdentifier(value);
        }
    }
}
