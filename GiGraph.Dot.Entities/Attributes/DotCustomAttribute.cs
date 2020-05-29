namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// An attribute with any key and any value that are supported by a destination DOT graph renderer.
    /// </summary>
    public class DotCustomAttribute : DotCommonAttribute<string>
    {
        /// <summary>
        /// Creates a new custom attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute in a format understood by a destination DOT graph renderer.</param>
        public DotCustomAttribute(string key, string value)
            : base(key, value)
        {
        }
    }
}
