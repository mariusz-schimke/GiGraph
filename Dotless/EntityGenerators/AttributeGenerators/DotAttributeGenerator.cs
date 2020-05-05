using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotWriters;
using Dotless.EntityGenerators.Options;

namespace Dotless.EntityGenerators.AttributeGenerators
{
    public abstract class DotAttributeGenerator<TAttribute> : DotEntityGenerator<TAttribute, IDotAttributeWriter>
        where TAttribute : DotAttribute
    {
        public DotAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected abstract string GetAttributeValue(TAttribute attribute);

        public override void Write(TAttribute attribute, IDotAttributeWriter writer)
        {
            if (((IDotAttribute)attribute).HasValue)
            {
                var value = GetAttributeValue(attribute);
                WriteAttribute(((IDotAttribute)attribute).Key, value, writer);
            }
        }

        protected virtual string EscapeKey(string key)
        {
            return EscapeId(key)!;
        }

        protected virtual bool KeyRequiresQuoting(string key)
        {
            return !_syntaxRules.IsValidIdentifier(key);
        }

        protected virtual bool ValueRequiresQuoting(string value)
        {
            return _options.Attributes.PreferQuotedValue || !_syntaxRules.IsValidIdentifier(value);
        }

        protected virtual void WriteAttribute(string key, string value, IDotAttributeWriter writer)
        {
            key = EscapeKey(key);

            writer.WriteAttribute
            (
                key,
                quoteKey: KeyRequiresQuoting(key),
                value,
                quoteValue: ValueRequiresQuoting(value)
            );
        }
    }
}
