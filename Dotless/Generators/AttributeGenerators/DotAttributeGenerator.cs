using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.Generators.AttributeGenerators
{
    public abstract class DotAttributeGenerator<TAttribute, TAttributeValue> : IEntityGenerator<TAttribute>
        where TAttribute : DotAttribute<TAttributeValue>
    {
        public abstract ICollection<IDotToken> Generate(TAttribute attribute);

        ICollection<IDotToken> IDotEntityGenerator.Generate(IDotEntity attribute)
        {
            return Generate((TAttribute)attribute);
        }
    }
}
