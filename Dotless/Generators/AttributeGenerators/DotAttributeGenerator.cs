using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;
using System.Linq;

namespace Dotless.Generators.AttributeGenerators
{
    public abstract class DotAttributeGenerator<TAttribute> : IEntityGenerator<TAttribute>
        where TAttribute : IDotAttribute
    {
        protected abstract ICollection<IDotToken>? ConvertValueToTokens(TAttribute attribute);

        public virtual ICollection<IDotToken> Generate(TAttribute attribute)
        {
            var result = new List<IDotToken>();
            var valueAsTokens = ConvertValueToTokens(attribute);

            if (true != valueAsTokens?.Any())
            {
                return result;
            }

            return result
                .AttributeKey(attribute.Key)
                .AssignmentOperator()
                .Tokens(valueAsTokens);
        }


        ICollection<IDotToken> IDotEntityGenerator.Generate(IDotEntity attribute)
        {
            return Generate((TAttribute)attribute);
        }
    }
}
