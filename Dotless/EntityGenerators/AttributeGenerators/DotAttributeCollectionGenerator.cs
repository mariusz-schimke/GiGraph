using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotWriters;
using Dotless.EntityGenerators.Options;
using System.Linq;

namespace Dotless.EntityGenerators.AttributeGenerators
{
    public class DotAttributeCollectionGenerator : DotEntityGenerator<DotAttributeCollection, IDotAttributeCollectionWriter>
    {
        public DotAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Write(DotAttributeCollection attributes, IDotAttributeCollectionWriter writer)
        {
            var orderedAttributes = attributes.OrderBy((IDotAttribute a) => a.Key).ToList();

            foreach (var attribute in orderedAttributes)
            {
                var nodeWriter = writer.BeginAttribute();
                _entityGenerators.GetForEntity<IDotAttributeWriter>(attribute).Write(attribute, nodeWriter);
                writer.EndAttribute();
            }
        }
    }
}
