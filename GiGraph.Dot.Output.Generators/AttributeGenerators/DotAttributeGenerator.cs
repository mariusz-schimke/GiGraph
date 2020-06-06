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
        protected DotAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
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
            value = EscapeValue(FormatValue(value));

            writer.WriteAttribute
            (
                key,
                quoteKey: KeyRequiresQuoting(key),
                value,
                quoteValue: ValueRequiresQuoting(value)
            );
        }

        protected virtual string FormatValue(string value) => value;
        protected virtual string EscapeValue(string value) => value;
        
        protected virtual bool KeyRequiresQuoting(string key) => !_syntaxRules.IsValidIdentifier(key);
        protected virtual bool ValueRequiresQuoting(string value) => _options.Attributes.PreferQuotedValue || !_syntaxRules.IsValidIdentifier(value);
    }
}