namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// String attribute. The text provided will be escaped on graph generation, 
    /// so when the graph is visualized, the text will be displayed exactly the way it is provided here.
    /// </summary>
    public class DotStringAttribute : DotAttribute<string>
    {
        /// <summary>
        /// Creates a new instance of a string attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute. The text will be escaped on graph generation, 
        /// so when the graph is visualized, it will be displayed exactly the way it is provided here.</param>
        public DotStringAttribute(string key, string value)
            : base(key, value)
        {
        }
    }
}
