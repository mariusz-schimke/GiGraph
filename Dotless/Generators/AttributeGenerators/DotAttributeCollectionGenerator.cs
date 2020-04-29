using Dotless.Core;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;
using System.Linq;

namespace Dotless.Generators.AttributeGenerators
{
    public class DotAttributeCollectionGenerator : IEntityGenerator<DotAttributeCollection>
    {
        protected readonly DotEntityGeneratorCollection _entityGenerators;

        public DotAttributeCollectionGenerator(DotEntityGeneratorCollection entityGenerators)
        {
            _entityGenerators = entityGenerators;
        }

        public ICollection<IDotToken> Generate(DotAttributeCollection attributes)
        {
            var result = new List<IDotToken>();

            if (!attributes.Any())
            {
                return result;
            }

            result.AttributeCollectionStart();
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

            result.AttributeCollectionEnd();

            return result;
        }

        ICollection<IDotToken> IDotEntityGenerator.Generate(IDotEntity attributes)
        {
            return Generate((DotAttributeCollection)attributes);
        }
    }
}
