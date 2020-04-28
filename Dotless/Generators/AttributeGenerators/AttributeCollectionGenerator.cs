using Dotless.Core;
using Dotless.DotBuilders;
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

        public ICollection<IToken> Generate(AttributeCollection attributes)
        {
            var result = new List<IToken>();

            if (!attributes.Any())
            {
                return result;
            }

            result.AttributeBlockStart();
            var attributeList = attributes.ToList();

            for (int i = 0; i < attributeList.Count; i++)
            {
                var generator = _entityGenerators.GetForTypeOrForAnyBaseType(attributeList[i]);
                var tokens = generator.Generate(attributeList[i]);

                result.AddRange(tokens);

                if (i < attributeList.Count - 1)
                {
                    result.AttributeSeparator();
                }
            }

            result.AttributeBlockEnd();

            return result;
        }

        ICollection<IToken> IEntityGenerator.Generate(IEntity attributes)
        {
            return Generate((AttributeCollection)attributes);
        }
    }
}
