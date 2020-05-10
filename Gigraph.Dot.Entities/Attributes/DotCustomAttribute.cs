namespace Gigraph.Dot.Entities.Attributes
{
    /// <summary>
    /// An attribute with any key and any value that are supported by a destination DOT graph renderer.
    /// </summary>
    public class DotCustomAttribute : DotAttribute<string>
    {
        public DotCustomAttribute(string key, string value)
            : base(key, value)
        {
        }
    }
}
