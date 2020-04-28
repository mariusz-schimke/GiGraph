using Dotless.Core;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;
using System.Linq;

namespace Dotless.Generators.AttributeGenerators
{
    public class AttributeCollectionGenerator : IEntityGenerator<AttributeCollection>
    {
        protected readonly EntityGeneratorCollection _entityGenerators;

        public AttributeCollectionGenerator(EntityGeneratorCollection entityGenerators)
        {
            _entityGenerators = entityGenerators;
        }

        public ICollection<IToken> Generate(AttributeCollection attributes, GeneratorOptions options)
        {
            var result = new List<IToken>();

            if (!attributes.Any())
            {
                return result;
            }

            result.AttributeBlockStart();

            foreach (var attribute in attributes)
            {
                var generator = _entityGenerators.GetForTypeOrForAnyBaseType(attribute);
                var tokens = generator.Generate(attribute, options);

                result.AddRange(tokens);
            }

            result.AttributeBlockEnd();

            return result;
        }

        ICollection<IToken> IEntityGenerator.Generate(IEntity attributes, GeneratorOptions options)
        {
            return Generate((AttributeCollection)attributes, options);
        }
    }
}
