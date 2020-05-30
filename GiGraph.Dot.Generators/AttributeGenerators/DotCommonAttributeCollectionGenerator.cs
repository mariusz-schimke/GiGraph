using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
using GiGraph.Dot.Writers.AttributeWriters;
using System.Linq;

namespace GiGraph.Dot.Generators.AttributeGenerators
{
    public class DotCommonAttributeCollectionGenerator : DotEntityGenerator<DotCommonAttributeCollection, IDotAttributeStatementWriter>
    {
        protected DotCommonAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotCommonAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonAttributeCollection attributes, IDotAttributeStatementWriter writer)
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

        protected virtual void WriteAttribute(DotCommonAttribute attribute, IDotAttributeStatementWriter writer)
        {
            var nodeWriter = writer.BeginAttribute();
            _entityGenerators.GetForEntity<IDotAttributeWriter>(attribute).Generate(attribute, nodeWriter);
            writer.EndAttribute();
        }
    }
}
