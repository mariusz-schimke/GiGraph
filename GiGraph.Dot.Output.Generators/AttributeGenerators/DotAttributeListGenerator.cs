using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Writers.AttributeWriters;

namespace GiGraph.Dot.Output.Generators.AttributeGenerators
{
    public class DotAttributeListGenerator : DotAttributeCollectionGenerator<IDotAttributeListItemWriter>
    {
        public DotAttributeListGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteAttribute(DotAttribute attribute, IDotAttributeListItemWriter writer)
        {
            var nodeWriter = writer.BeginAttribute();
            _entityGenerators.GetForEntity<IDotAttributeWriter>(attribute).Generate(attribute, nodeWriter);
            writer.EndAttribute();
        }
    }
}