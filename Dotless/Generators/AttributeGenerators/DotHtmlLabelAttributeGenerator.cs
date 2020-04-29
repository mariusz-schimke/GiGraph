using Dotless.Attributes;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public class DotHtmlLabelAttributeGenerator : DotTextualAttributeGenerator<DotHtmlLabel>
    {
        public override ICollection<IDotToken> Generate(DotHtmlLabel attribute)
        {
            var result = new List<IDotToken>();

            if (attribute.Value is null)
            {
                return result;
            }

            result.AttributeKey(attribute.Key);
            result.AssignmentOperator();
            result.BracedHtmlText(EscapeValue(attribute.Value)!);

            return result;
        }
    }
}
