using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
using System.Linq;
using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Generators.AttributeGenerators
{
    public abstract class DotCommonAttributeCollectionGenerator<TWriter> : DotEntityGenerator<DotCommonAttributeCollection, TWriter>
        where TWriter : IDotEntityWriter
    {
        protected DotCommonAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotCommonAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonAttributeCollection attributes, TWriter writer)
        {
            var orderedAttributes = _options.OrderElements
                ? attributes.Cast<IDotOrderableEntity>()
                            .OrderBy(attribute => attribute.OrderingKey)
                            .Cast<DotCommonAttribute>()
                : attributes;

            foreach (var attribute in orderedAttributes)
            {
                WriteAttribute(attribute, writer);
            }
        }

        protected abstract void WriteAttribute(DotCommonAttribute attribute, TWriter writer);
    }
}