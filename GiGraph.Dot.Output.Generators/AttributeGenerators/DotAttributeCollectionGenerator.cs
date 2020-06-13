using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Options;
using System.Linq;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.TextEscaping;
using GiGraph.Dot.Output.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Output.Generators.AttributeGenerators
{
    public abstract class DotAttributeCollectionGenerator<TWriter> : DotEntityGenerator<DotAttributeCollection, TWriter>
        where TWriter : IDotEntityWriter
    {
        protected DotAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, IDotTextEscaper identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotAttributeCollection attributes, TWriter writer)
        {
            var orderedAttributes = _options.OrderElements
                ? attributes.Values
                            .Cast<IDotOrderableEntity>()
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