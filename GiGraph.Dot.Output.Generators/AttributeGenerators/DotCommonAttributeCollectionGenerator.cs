using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Options;
using System.Linq;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Generators.TextEscaping;
using GiGraph.Dot.Output.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Output.Generators.AttributeGenerators
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