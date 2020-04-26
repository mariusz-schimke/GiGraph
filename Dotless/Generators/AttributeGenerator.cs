using Dotless.Attributes;

namespace Dotless.Generators
{
    public abstract class AttributeGenerator<TAttribute, TAttributeValue> : IEntityGenerator<TAttribute>
        where TAttribute : Attribute<TAttributeValue>
    {
        public string Key { get; }

        public AttributeGenerator(string key)
        {
            Key = key;
        }

        public abstract string? Generate(TAttribute attribute, GeneratorOptions options);

        string? IEntityGenerator.Generate(object attribute, GeneratorOptions options)
        {
            return Generate((TAttribute)attribute, options);
        }
    }
}
