using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotWriters;
using Dotless.Writers.Options;

namespace Dotless.Writers.AttributeWriters
{
    public abstract class DotAttributeWriter<TAttribute> : DotEntityWriter<TAttribute>
        where TAttribute : IDotAttribute
    {
        public DotAttributeWriter(DotSyntaxRules syntaxRules, DotWriterOptions options, DotEntityWriterCollection entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected abstract string GetAttributeValue(TAttribute attribute);

        public override void Write(TAttribute attribute, DotStringWriter writer)
        {
            if (!attribute.HasValue)
            {
                return;
            }

            var value = GetAttributeValue(attribute);
            WriteAttribute(attribute.Key, value, writer);
        }

        protected virtual bool IdRequiresQuoting(string id)
        {
            return !_syntaxRules.IsValidIdentifier(id);
        }

        protected virtual bool ValueRequiresQuoting(string value)
        {
            return _options.Attributes.PreferQuotedValue || !_syntaxRules.IsValidIdentifier(value);
        }

        protected virtual void WriteAttribute(string key, string value, DotStringWriter writer)
        {
            writer
                .AssertContext<DotStringWriter.AttributesContext>()
                .WriteAttribute
                (
                    key,
                    quoteKey: IdRequiresQuoting(key),
                    value,
                    quoteValue: ValueRequiresQuoting(value)
                );
        }
    }
}
