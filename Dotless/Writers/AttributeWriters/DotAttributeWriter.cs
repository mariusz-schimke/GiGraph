using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotWriters;
using Dotless.Writers.Options;

namespace Dotless.Writers.AttributeWriters
{
    public abstract class DotAttributeWriter<TAttribute> : DotEntityWriter<TAttribute>
        where TAttribute : DotAttribute
    {
        public DotAttributeWriter(DotSyntaxRules syntaxRules, DotWriterOptions options, DotEntityWriterCollection entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected abstract string GetAttributeValue(TAttribute attribute);

        public override bool Write(TAttribute attribute, DotStringWriter writer)
        {
            if (((IDotAttribute)attribute).HasValue)
            {
                var value = GetAttributeValue(attribute);
                return WriteAttribute(((IDotAttribute)attribute).Key, value, writer);
            }

            return false;
        }

        protected virtual bool IdRequiresQuoting(string id)
        {
            return !_syntaxRules.IsValidIdentifier(id);
        }

        protected virtual bool ValueRequiresQuoting(string value)
        {
            return _options.Attributes.PreferQuotedValue || !_syntaxRules.IsValidIdentifier(value);
        }

        protected virtual bool WriteAttribute(string key, string value, DotStringWriter writer)
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

            return true;
        }
    }
}
