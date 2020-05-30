namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// An HTML string attribute that can be used as element label.
    /// <see href="https://www.graphviz.org/doc/info/shapes.html#html">See supported HTML grammar</see>.
    /// </summary>
    public class DotHtmlAttribute : DotCommonAttribute<string>
    {
        /// <summary>
        /// Creates a new HTML attribute with a key of "label".
        /// </summary>
        /// <param name="html">The HTML text of the attribute.
        /// <see href="https://www.graphviz.org/doc/info/shapes.html#html">See supported HTML grammar</see>.
        /// </param>
        public DotHtmlAttribute(string html)
            : base("label", html)
        {
        }

        /// <summary>
        /// Creates a new HTML attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="html">The HTML text of the attribute.
        /// <see href="https://www.graphviz.org/doc/info/shapes.html#html">See supported HTML grammar</see>.
        /// </param>
        public DotHtmlAttribute(string key, string html)
            : base(key, html)
        {
        }
    }
}
