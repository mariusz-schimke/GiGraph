using GiGraph.Dot.Core;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Writers.AttributeWriters;

namespace GiGraph.Dot.Generators.AttributeGenerators
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
            WriteAttribute
            (
                ((IDotAttribute)attribute).Key,
                ((IDotAttribute)attribute).Value,
                writer
            );
        }

        protected virtual void WriteAttribute(string key, string value, IDotAttributeWriter writer)
        {
            key = EscapeKey(key);
            value = EscapeValue(value);

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
