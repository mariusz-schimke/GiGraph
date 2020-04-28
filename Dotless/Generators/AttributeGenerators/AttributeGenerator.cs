using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public abstract class AttributeGenerator<TAttribute, TAttributeValue> : IEntityGenerator<TAttribute>
        where TAttribute : Attribute<TAttributeValue>
    {
        public abstract ICollection<IToken> Generate(TAttribute attribute);

        ICollection<IToken> IEntityGenerator.Generate(IEntity attribute)
        {
            return Generate((TAttribute)attribute);
        }
    }
}
