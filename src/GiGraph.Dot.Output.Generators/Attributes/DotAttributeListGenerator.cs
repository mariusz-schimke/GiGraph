using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Attributes;

namespace GiGraph.Dot.Output.Generators.Attributes
{
    public class DotAttributeListGenerator : DotAttributeCollectionGenerator<IDotAttributeListItemWriter>
    {
        public DotAttributeListGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteAttribute(DotAttribute attribute, IDotAttributeListItemWriter writer)
        {
            var attributeWriter = writer.BeginAttribute();
            _entityGenerators.GetForEntity<IDotAttributeWriter>(attribute).Generate(attribute, attributeWriter);
            writer.EndAttribute();
        }
    }
}