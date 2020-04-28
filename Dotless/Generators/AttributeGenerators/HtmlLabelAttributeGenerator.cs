using Dotless.Attributes;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public class HtmlLabelAttributeGenerator : TextualAttributeGenerator<HtmlLabel>
    {
        public override ICollection<IToken> Generate(HtmlLabel attribute, GeneratorOptions options)
        {
            var result = new List<IToken>();

            if (attribute.Value is null)
            {
                return result;
            }

            result.AttributeKey(attribute.Key);
            result.AssignmentOperator();
            result.HtmlBlock(EscapeValue(attribute.Value)!);

            return result;
        }
    }
}
