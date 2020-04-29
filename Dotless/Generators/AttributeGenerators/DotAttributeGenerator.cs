using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;
using System.Linq;

namespace Dotless.Generators.AttributeGenerators
{
    public abstract class DotAttributeGenerator<TAttribute> : DotEntityGenerator<TAttribute>
        where TAttribute : IDotAttribute
    {
        public DotAttributeGenerator(DotSyntaxRules syntaxRules, DotEntityGeneratorCollection entityGenerators)
            : base(syntaxRules, entityGenerators)
        {
        }

        protected abstract ICollection<IDotToken>? ConvertValueToTokens(TAttribute attribute, DotEntityGeneratorOptions options);

        public override ICollection<IDotToken> Generate(TAttribute attribute, DotEntityGeneratorOptions options)
        {
            var result = new List<IDotToken>();
            var valueAsTokens = ConvertValueToTokens(attribute, options);

            if (true != valueAsTokens?.Any())
            {
                return result;
            }

            return result
                .AttributeKey(attribute.Key)
                .AssignmentOperator()
                .Tokens(valueAsTokens);
        }
    }
}
