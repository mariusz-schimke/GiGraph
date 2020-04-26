using Dotless.Attributes;
using Dotless.Core;

namespace Dotless.Generators.AttributeGenerators
{
    public abstract class AttributeGenerator<TAttribute, TAttributeValue> : IEntityGenerator<TAttribute>
        where TAttribute : Attribute<TAttributeValue>
    {
        public abstract string? Generate(TAttribute attribute, GeneratorOptions options);

        string? IEntityGenerator.Generate(IEntity attribute, GeneratorOptions options)
        {
            return Generate((TAttribute)attribute, options);
        }
    }
}
