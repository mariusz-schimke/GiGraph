using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    public abstract class DotAttribute : IDotEntity, IDotAnnotable, IDotEncodable, IDotOrderable
    {
        /// <summary>
        /// Gets the key of the attribute.
        /// </summary>
        public virtual string Key { get; }

        string IDotOrderable.OrderingKey => Key;

        protected internal abstract object GetValue();

        public virtual string Annotation { get; set; }

        /// <summary>
        /// Gets the value of the attribute in a format understood by DOT graph renderer.
        /// </summary>
        /// <param name="options">The DOT generation options to use.</param>
        /// <param name="syntaxRules">The DOT syntax rules to use.</param>
        protected internal abstract string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules);

        protected DotAttribute(string key)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key), "Attribute key cannot be null.");
        }

        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules) => GetDotEncodedValue(options, syntaxRules);
    }
}