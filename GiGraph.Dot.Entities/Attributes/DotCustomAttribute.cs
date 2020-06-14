namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// An attribute with any key and any value that are directly supported by a destination DOT graph renderer.
    /// The value specified for the attribute will be rendered as is in the output script (without escaping or any other processing).
    /// </summary>
    public class DotCustomAttribute : DotAttribute<string>
    {
        /// <summary>
        /// Creates a new custom attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute in a format understood by a destination DOT graph renderer.
        /// The value will be rendered as is in the output script (without escaping).</param>
        public DotCustomAttribute(string key, string value)
            : base(key, value)
        {
        }
    }
}