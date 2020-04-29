using Dotless.Core;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;
using System.Linq;

namespace Dotless.Generators.AttributeGenerators
{
    public class DotAttributeCollectionGenerator : DotEntityGenerator<DotAttributeCollection>
    {
        public DotAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotEntityGeneratorCollection entityGenerators)
            : base(syntaxRules, entityGenerators)
        {
        }

        public override ICollection<IDotToken> Generate(DotAttributeCollection attributes, DotEntityGeneratorOptions options)
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
                var tokens = generator.Generate(attributeList[i], options);

                result.AddRange(tokens);

                if (i < attributeList.Count - 1)
                {
                    result.AttributeSeparator();
                }
            }

            result.AttributeCollectionEnd();

            return result;
        }
    }
}
