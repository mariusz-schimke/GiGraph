using System.Linq;
using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers;

namespace GiGraph.Dot.Output.Generators.Attributes
{
    public abstract class DotAttributeCollectionGenerator<TWriter> : DotEntityGenerator<DotAttributeCollection, TWriter>
        where TWriter : IDotEntityWriter
    {
        protected DotAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotAttributeCollection attributes, TWriter writer)
        {
            var orderedAttributes = _options.SortElements
                ? attributes.Values
                   .Cast<IDotOrderable>()
                   .OrderBy(attribute => attribute.OrderingKey)
                   .Cast<DotAttribute>()
                : attributes.Values;

            foreach (var attribute in orderedAttributes)
            {
                WriteAttribute(attribute, writer);
            }
        }

        protected abstract void WriteAttribute(DotAttribute attribute, TWriter writer);
    }
}