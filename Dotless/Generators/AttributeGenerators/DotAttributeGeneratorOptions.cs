namespace Dotless.Generators.AttributeGenerators
{
    public class DotAttributeGeneratorOptions
    {
        /// <summary>
        /// When set, attribute value will always be quoted, even if that is not required.
        /// </summary>
        public bool PreferQuotedValue { get; set; } = true;
    }
}
