using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes;
using Gigraph.Dot.Generators.CommonEntityGenerators;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.AttributeWriters;

namespace Gigraph.Dot.Generators.AttributeGenerators
{
    public class DotAttributeGenerator<TAttribute> : DotEntityGenerator<TAttribute, IDotAttributeWriter>
        where TAttribute : DotAttribute
    {
        public DotAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(TAttribute attribute, IDotAttributeWriter writer)
        {
            WriteAttribute(attribute, writer);
        }

        protected virtual void WriteAttribute(TAttribute attribute, IDotAttributeWriter writer)
        {
            var key = EscapeKey(((IDotAttribute)attribute).Key);
            var value = EscapeValue(((IDotAttribute)attribute).Value);

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
