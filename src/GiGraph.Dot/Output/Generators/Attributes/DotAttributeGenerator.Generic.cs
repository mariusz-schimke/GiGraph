﻿using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Output.Writers.Attributes;

namespace GiGraph.Dot.Output.Generators.Attributes;

public class DotAttributeGenerator<TAttribute> : DotEntityGenerator<TAttribute, IDotAttributeWriter>
    where TAttribute : DotAttribute, IDotEncodable
{
    public DotAttributeGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
        : base(syntaxRules, options, entityGenerators)
    {
    }

    protected override void WriteEntity(TAttribute attribute, IDotAttributeWriter writer)
    {
        WriteAttribute
        (
            attribute.Key,
            attribute.GetDotEncodedValue(_options, _syntaxRules),
            writer
        );
    }

    protected virtual void WriteAttribute(string key, string? value, IDotAttributeWriter writer)
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

    protected virtual string EscapeKey(string key) => _syntaxRules.Attributes.KeyEscaper.Escape(key);

    protected virtual bool KeyRequiresQuoting(string key) => _options.Attributes.PreferQuotedKey || !_syntaxRules.IsValidIdentifier(key);

    protected virtual bool ValueRequiresQuoting(string? value) => _options.Attributes.PreferQuotedValue || !_syntaxRules.IsValidIdentifier(value);

    protected virtual bool ValueRequiresQuoting(string[] valueParts) => ValueRequiresQuoting(string.Join(string.Empty, valueParts));
}