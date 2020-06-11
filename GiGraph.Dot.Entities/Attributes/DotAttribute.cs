using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    public abstract class DotAttribute : IDotEncodableValue, IDotOrderableEntity
    {
        /// <summary>
        /// Gets the key of the attribute.
        /// </summary>
        public virtual string Key { get; }

        string IDotOrderableEntity.OrderingKey => Key;

        /// <summary>
        /// Gets the value of the attribute in a format understood by DOT graph renderer.
        /// </summary>
        /// <param name="options">The DOT generation options to use.</param>
        protected internal abstract string GetDotEncodedValue(DotGenerationOptions options);

        protected DotAttribute(string key)
        {
            Key = key;
        }

        string IDotEncodableValue.GetDotEncodedValue(DotGenerationOptions options) => GetDotEncodedValue(options);
    }
}