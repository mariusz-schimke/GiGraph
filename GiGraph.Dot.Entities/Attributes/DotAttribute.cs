using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    public abstract class DotAttribute : IDotAttribute, IDotOrderableEntity
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
        protected abstract string GetDotEncodedValue(DotGenerationOptions options);

        protected DotAttribute(string key)
        {
            Key = key;
        }

        string IDotAttribute.GetDotEncodedValue(DotGenerationOptions options) => GetDotEncodedValue(options);
    }
}