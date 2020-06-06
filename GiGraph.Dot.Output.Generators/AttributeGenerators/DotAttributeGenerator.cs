using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Generators.TextEscaping;
using GiGraph.Dot.Output.Writers.AttributeWriters;

namespace GiGraph.Dot.Output.Generators.AttributeGenerators
{
    public class DotAttributeGenerator<TAttribute> : DotEntityGenerator<TAttribute, IDotAttributeWriter>
        where TAttribute : DotCommonAttribute, IDotAttribute
    {
        protected readonly TextEscapingPipeline _valueEscaper;

        protected DotAttributeGenerator(
            DotSyntaxRules syntaxRules,
            DotGenerationOptions options,
            IDotEntityGeneratorsProvider entityGenerators,
            TextEscapingPipeline identifierEscaper = null,
            TextEscapingPipeline valueEscaper = null)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
            _valueEscaper = valueEscaper ?? TextEscapingPipeline.Default();
        }

        public DotAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : this(syntaxRules, options, entityGenerators, identifierEscaper: null, valueEscaper: null)
        {
        }

        public override void Generate(TAttribute attribute, IDotAttributeWriter writer)
        {
            WriteAttribute
            (
                attribute.Key,
                attribute.GetDotEncodedValue(_options),
                writer
            );
        }

        protected virtual void WriteAttribute(string key, string value, IDotAttributeWriter writer)
        {
            key = EscapeIdentifier(key);
            value = EscapeValue(value);

            writer.WriteAttribute
            (
                key,
                quoteKey: KeyRequiresQuoting(key),
                value,
                quoteValue: ValueRequiresQuoting(value)
            );
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
