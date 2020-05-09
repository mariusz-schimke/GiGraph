using Gigraph.Dot.Entities.Attributes;
using Gigraph.Dot.Core;
using Gigraph.Dot.Writers;
using Gigraph.Dot.Generators.Options;
using System.Linq;

namespace Gigraph.Dot.Generators.AttributeGenerators
{
    public class DotAttributeCollectionGenerator : DotEntityGenerator<DotAttributeCollection, IDotAttributeCollectionWriter>
    {
        public DotAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotAttributeCollection attributes, IDotAttributeCollectionWriter writer)
        {
            var orderedAttributes = attributes.OrderBy((IDotAttribute a) => a.Key).ToList();

            foreach (var attribute in orderedAttributes)
            {
                var nodeWriter = writer.BeginAttribute();
                _entityGenerators.GetForEntity<IDotAttributeWriter>(attribute).Generate(attribute, nodeWriter);
                writer.EndAttribute();
            }
        }
    }
}
