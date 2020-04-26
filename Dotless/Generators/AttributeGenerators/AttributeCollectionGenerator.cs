using Dotless.Core;
using Dotless.Generators.Extensions;
using System.Text;

namespace Dotless.Generators.AttributeGenerators
{
    public class AttributeCollectionGenerator : IEntityGenerator<AttributeCollection>
    {
        protected readonly EntityGeneratorCollection _entityGenerators;

        public AttributeCollectionGenerator(EntityGeneratorCollection entityGenerators)
        {
            _entityGenerators = entityGenerators;
        }

        public string? Generate(AttributeCollection attributes, GeneratorOptions options)
        {
            var result = new StringBuilder();

            AttributesBlockStart(result, options);

            Attributes(result, attributes, options.IncreaseIndentation());

            AttributesBlockEnd(result, options);

            return result.ToString();
        }


        protected virtual void AttributesBlockStart(StringBuilder result, GeneratorOptions options)
        {
            result.Append("[");
            result.Append(options.LBoS());
        }

        protected virtual void Attributes(StringBuilder result, AttributeCollection attributes, GeneratorOptions options)
        {
            foreach (var attribute in attributes.ToList())
            {
                var generator = _entityGenerators.GetForTypeOrForAnyBaseType(attribute);
                result.Append(generator.Generate(attribute, options));
            }
        }

        protected virtual void AttributesBlockEnd(StringBuilder result, GeneratorOptions options)
        {
            result.Append("]");
            result.Append(options.LBoS());
        }

        string? IEntityGenerator.Generate(IEntity attributes, GeneratorOptions options)
        {
            return Generate((AttributeCollection)attributes, options);
        }
    }
}
