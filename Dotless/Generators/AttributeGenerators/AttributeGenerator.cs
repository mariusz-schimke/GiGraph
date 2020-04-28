using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public abstract class AttributeGenerator<TAttribute, TAttributeValue> : IEntityGenerator<TAttribute>
        where TAttribute : Attribute<TAttributeValue>
    {
        public abstract ICollection<IToken> Generate(TAttribute attribute, GeneratorOptions options);

        ICollection<IToken> IEntityGenerator.Generate(IEntity attribute, GeneratorOptions options)
        {
            return Generate((TAttribute)attribute, options);
        }
    }
}
