using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Output.Writers;

namespace GiGraph.Dot.Output.Generators.Attributes;

public abstract class DotAttributeCollectionGenerator<TWriter> : DotEntityGenerator<DotAttributeCollection, TWriter>
    where TWriter : IDotEntityWriter
{
    protected DotAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
        : base(syntaxRules, options, entityGenerators)
    {
    }

    protected override void WriteEntity(DotAttributeCollection attributes, TWriter writer)
    {
        var orderedAttributes = _options.SortElements
            ? attributes
                .Cast<IDotOrderable>()
                .OrderBy(attribute => attribute.OrderingKey, StringComparer.InvariantCulture)
                .Cast<DotAttribute>()
            : attributes;

        foreach (var attribute in orderedAttributes)
        {
            WriteAttribute(attribute, writer);
        }
    }

    protected abstract void WriteAttribute(DotAttribute attribute, TWriter writer);
}